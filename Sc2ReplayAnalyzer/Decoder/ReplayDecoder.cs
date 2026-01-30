using MPQArchive.MPQ;
using Sc2ReplayAnalyzer.Json.MetaData;
using Sc2ReplayAnalyzer.Json.protocol90870.BitPacked;
using Sc2ReplayAnalyzer.Json.protocol90870.Versioned;

namespace Sc2ReplayAnalyzer.Decoder;

public class ReplayDecoder
{
    private Dictionary<string, byte[]> _listingFiles;

    public void Decode(string path)
    {
        using var fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        var mpqArchive = new MPQReader(fileStream).Read();
        var userData = mpqArchive.MPQUserData;

        using var binaryReader = new BinaryReader(new MemoryStream(mpqArchive.MPQUserData.Content));

        var parser = new VersionedProtocolParser(binaryReader);
        var header = parser.Parse_ReplaySHeader();

        _listingFiles = mpqArchive.ListingFiles;

        ParseMetaData();
        ParseReplayInitData();
        ParseMessageEvents();
        ParseReplayDetails();
        ParseTrackerEvents();
        ParseGameEvents();
    }

    private void ParseMetaData()
    {
        using var stream = new MemoryStream(_listingFiles["replay.gamemetadata.json"]);
        var metaData = System.Text.Json.JsonSerializer.Deserialize<ReplayMetadata>(stream);
    }

    private void ParseReplayInitData()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.initData"]));

        var bitPackedParser = new BitPackedProtocolParser(reader);
        var initData = bitPackedParser.Parse_ReplaySInitData();
    }

    private void ParseMessageEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.message.events"]));

        var bitPackedParser = new BitPackedProtocolParser(reader);
        var info = new List<string>();

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            var messageTriples = ParseMessageEventTriplet(bitPackedParser, info);
        }
    }

    private void ParseReplayDetails()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.details"]));

        var versionedParser = new VersionedProtocolParser(reader);
        var replayDetails = versionedParser.Parse_GameSDetails();
    }

    private void ParseGameEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.game.events"]));
        var bitPackedParser = new BitPackedProtocolParser(reader);

        var info = new List<string>();

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            var gameTriples = ParseGameEventTriplet(bitPackedParser, info);
        }
    }

    private void ParseTrackerEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.tracker.events"]));
        var versionedParser = new VersionedProtocolParser(reader);

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            var eventPair = ParseEventPair(versionedParser);
        }
    }

    private EventPair ParseEventPair(VersionedProtocolParser trackerParser)
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

        return new EventPair
        {
            Delta = deltaValue,
            TrackerEventID = eventID
        };
    }

    private GameEventTriplet ParseGameEventTriplet(BitPackedProtocolParser bitPackedParser, List<string> info)
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

    private MessageEventTriplet ParseMessageEventTriplet(BitPackedProtocolParser bitPackedParser, List<string> info)
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
