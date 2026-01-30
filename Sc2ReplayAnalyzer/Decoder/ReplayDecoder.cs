using MPQArchive.MPQ;
using MPQArchive.MPQ.ReceivedData;
using Sc2ReplayAnalyzer.Decoder.APIModel;
using Sc2ReplayAnalyzer.Decoder.Events.MetaData;
using Sc2ReplayAnalyzer.Decoder.Parser;
using Sc2ReplayAnalyzer.Json.MetaData;
using Sc2ReplayAnalyzer.Json.protocol90870.BitPacked;
using Sc2ReplayAnalyzer.Json.protocol90870.Versioned;

namespace Sc2ReplayAnalyzer.Decoder;

public class ReplayDecoder
{
    private Dictionary<string, byte[]> _listingFiles;

    internal Sc2ReplayData Decode(string path)
    {
        using var fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        var mpqArchive = new MPQReader(fileStream).Read();
        var userData = mpqArchive.MPQUserData;

        using var binaryReader = new BinaryReader(new MemoryStream(mpqArchive.MPQUserData.Content));

        var parser = new VersionedProtocolParser(binaryReader);
        var header = parser.Parse_ReplaySHeader();

        _listingFiles = mpqArchive.ListingFiles;

        return new Sc2ReplayData
        {
            HeaderData = ParseHeader(mpqArchive.MPQUserData),
            MetaData = ParseMetaData(),
            InitData = ParseReplayInitData(),
            MessagesData = ParseMessageEvents(),
            DetailsData = ParseReplayDetails(),
            TrackerData = ParseTrackerEvents(),
            GameData = ParseGameEvents(),
        };
    }

    private ReplaySHeader ParseHeader(MPQUserData userData)
    {
        using var binaryReader = new BinaryReader(new MemoryStream(userData.Content));
        var parser = new VersionedProtocolParser(binaryReader);

        return parser.Parse_ReplaySHeader();
    }

    private ReplayMetadata ParseMetaData()
    {
        using var stream = new MemoryStream(_listingFiles["replay.gamemetadata.json"]);

        return System.Text.Json.JsonSerializer.Deserialize<ReplayMetadata>(stream);
    }

    private ReplaySInitData ParseReplayInitData()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.initData"]));

        var bitPackedParser = new BitPackedProtocolParser(reader);

        return bitPackedParser.Parse_ReplaySInitData();
    }

    private IReadOnlyList<MessageEventTriplet> ParseMessageEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.message.events"]));

        var bitPackedParser = new BitPackedProtocolParser(reader);
        var result = new List<MessageEventTriplet>();

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            result.Add(ParseMessageEventTriplet(bitPackedParser));
        }

        return result;
    }

    private GameSDetails ParseReplayDetails()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.details"]));

        var versionedParser = new VersionedProtocolParser(reader);

        return versionedParser.Parse_GameSDetails();
    }

    private IReadOnlyList<GameEventTriplet> ParseGameEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.game.events"]));
        var bitPackedParser = new BitPackedProtocolParser(reader);

        var result = new List<GameEventTriplet>();

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            result.Add(ParseGameEventTriplet(bitPackedParser));
        }

        return result;
    }

    private IReadOnlyList<TrackerEventPair> ParseTrackerEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.tracker.events"]));
        var versionedParser = new VersionedProtocolParser(reader);
        var result = new List<TrackerEventPair>();

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            result.Add(ParseEventPair(versionedParser));
        }

        return result;
    }

    private TrackerEventPair ParseEventPair(VersionedProtocolParser trackerParser)
    {
        var delta = trackerParser.Parse_SVarUint32();
        var eventID = trackerParser.Parse_ReplayTrackerEEventId();

        uint deltaValue = delta switch
        {
            Json.protocol90870.Versioned.m_uint6 val => val.Value,
            Json.protocol90870.Versioned.m_uint14 val => val.Value,
            Json.protocol90870.Versioned.m_uint22 val => val.Value,
            Json.protocol90870.Versioned.m_uint32 val => val.Value,
            _ => throw new NotImplementedException(),
        };

        return new TrackerEventPair
        {
            Delta = deltaValue,
            TrackerEventID = eventID
        };
    }

    private GameEventTriplet ParseGameEventTriplet(BitPackedProtocolParser bitPackedParser)
    {
        var delta = bitPackedParser.Parse_SVarUint32();
        var gameUserID = bitPackedParser.Parse_ReplaySGameUserId();
        var eventID = bitPackedParser.Parse_GameEEventId();

        var realDelta = delta switch
        {
            Json.protocol90870.BitPacked.m_uint6 val => val.Value.Value,
            Json.protocol90870.BitPacked.m_uint14 val => val.Value.Value,
            Json.protocol90870.BitPacked.m_uint22 val => val.Value.Value,
            Json.protocol90870.BitPacked.m_uint32 val => val.Value.Value,
            _ => throw new NotImplementedException(),
        };

        bitPackedParser.byte_align();

        return new GameEventTriplet
        {
            Delta = realDelta,
            UserID = gameUserID.m_userId,
            EventID = eventID
        };
    }

    private MessageEventTriplet ParseMessageEventTriplet(BitPackedProtocolParser bitPackedParser)
    {
        var delta = bitPackedParser.Parse_SVarUint32();
        var gameUserID = bitPackedParser.Parse_ReplaySGameUserId();
        var eventID = bitPackedParser.Parse_GameEMessageId();

        var realDelta = delta switch
        {
            Json.protocol90870.BitPacked.m_uint6 val => val.Value.Value,
            Json.protocol90870.BitPacked.m_uint14 val => val.Value.Value,
            Json.protocol90870.BitPacked.m_uint22 val => val.Value.Value,
            Json.protocol90870.BitPacked.m_uint32 val => val.Value.Value,
            _ => throw new NotImplementedException(),
        };

        bitPackedParser.byte_align();

        return new MessageEventTriplet
        {
            Delta = realDelta,
            UserID = gameUserID.m_userId,
            EventID = eventID
        };
    }
}
