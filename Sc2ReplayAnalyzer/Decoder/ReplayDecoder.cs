using MPQArchive.MPQ;
using Sc2ReplayAnalyzer.Decoder.APIModel;
using Sc2ReplayAnalyzer.Decoder.Events.MetaData;
using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;
using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;
using Sc2ReplayAnalyzer.Decoder.Factory;
using Sc2ReplayAnalyzer.Json.protocol95299.Versioned;

using BitPacked = Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;
using Versioned = Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;
using GameSDetails = Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions.GameSDetails;
using Sc2ReplayAnalyzer.Global;
using System.Diagnostics;

namespace Sc2ReplayAnalyzer.Decoder;

public class ReplayDecoder
{
    private Dictionary<string, byte[]> _listingFiles;   
    private BitPackedProtocolParserFactory _bitPackedProtocolParserFactory;
    private VersionedProtocolParserFactory _versionedProtocolParserFactory;

    public int CorruptedReplays = 0;
    public long CurrentBuildNumber = 0;

    public Sc2Replay DecodeReplay(Stream fileStream)
    {
        var mpqArchive = new MPQReader(fileStream).Read();

        _listingFiles = mpqArchive.ListingFiles;

        var header = ParseHeader(mpqArchive.MPQUserData);

        CurrentBuildNumber = header.m_dataBuildNum;

        _bitPackedProtocolParserFactory = new BitPackedProtocolParserFactory(CurrentBuildNumber);
        _versionedProtocolParserFactory = new VersionedProtocolParserFactory(CurrentBuildNumber);

        var replayData = new Sc2ReplayData
        {
            MetaData = ParseMetaData(),
            InitData = ParseReplayInitData(),
            MessagesData = ParseMessageEvents(),
            DetailsData = ParseReplayDetails(),
            TrackerData = ParseTrackerEvents(),
            GameData = ParseGameEvents(),
        };

        return Sc2Replay.FromData(replayData);
    }

    public Sc2Replay DecodeReplay(string path)
    {
        using var fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);

        return DecodeReplay(fileStream);
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

        var bitPackedParser = _bitPackedProtocolParserFactory.Create(reader);

        var owo = bitPackedParser.Parse_ReplaySInitData();

        return owo;
    }

    private IReadOnlyList<MessageEventTriplet> ParseMessageEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.message.events"]));

        var bitPackedParser = _bitPackedProtocolParserFactory.Create(reader);
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

        var versionedParser = _versionedProtocolParserFactory.Create(reader);

        var owo = versionedParser.Parse_GameSDetails();

        return owo;
    }

    private IReadOnlyList<GameEventTriplet> ParseGameEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.game.events"]));
        var bitPackedParser = _bitPackedProtocolParserFactory.Create(reader);

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
        var versionedParser = _versionedProtocolParserFactory.Create(reader);
        var result = new List<TrackerEventPair>();

        try
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                result.Add(ParseEventPair(versionedParser));
            }
        }
        catch(ReplayCorruptedException)
        {
            ++CorruptedReplays;
        }

        return result;
    }

    private TrackerEventPair ParseEventPair(IVersionedProtocolParser trackerParser)
    {
        var delta = trackerParser.Parse_SVarUint32();
        uint deltaValue = delta switch
        {
            Versioned.m_uint6 val => val.Value,
            Versioned.m_uint14 val => val.Value,
            Versioned.m_uint22 val => val.Value,
            Versioned.m_uint32 val => val.Value,
            _ => throw new NotImplementedException(),

        };

        var eventID = trackerParser.Parse_ReplayTrackerEEventId();

        if (eventID is ReplayTrackerEEventId_e_unknown)
        {
            throw new ReplayCorruptedException("Unknown event id.");
        }

        return new TrackerEventPair
        {
            Delta = deltaValue,
            TrackerEventID = eventID
        };
    }

    private GameEventTriplet ParseGameEventTriplet(IBitPackedProtocolParser bitPackedParser)
   {
        var delta = bitPackedParser.Parse_SVarUint32();
        var gameUserID = bitPackedParser.Parse_ReplaySGameUserId();
        var eventID = bitPackedParser.Parse_GameEEventId();

        var realDelta = delta switch
        {
            BitPacked.m_uint6 val => val.Value.Value,
            BitPacked.m_uint14 val => val.Value.Value,
            BitPacked.m_uint22 val => val.Value.Value,
            BitPacked.m_uint32 val => val.Value.Value,
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

    private MessageEventTriplet ParseMessageEventTriplet(IBitPackedProtocolParser bitPackedParser)
    {
        var delta = bitPackedParser.Parse_SVarUint32();
        var gameUserID = bitPackedParser.Parse_ReplaySGameUserId();
        var eventID = bitPackedParser.Parse_GameEMessageId();

        var realDelta = delta switch
        {
            BitPacked.m_uint6 val => val.Value.Value,
            BitPacked.m_uint14 val => val.Value.Value,
            BitPacked.m_uint22 val => val.Value.Value,
            BitPacked.m_uint32 val => val.Value.Value,
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
