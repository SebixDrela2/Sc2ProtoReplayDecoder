using MPQArchive.MPQ;
using MPQArchive.MPQ.Constants;
using Sc2ReplayAnalyzer.Decoder.APIModel;
using Sc2ReplayAnalyzer.Decoder.Attributes;
using Sc2ReplayAnalyzer.Decoder.Events.MetaData;
using Sc2ReplayAnalyzer.Decoder.Factory;
using Sc2ReplayAnalyzer.Decoder.Parser;
using Sc2ReplayAnalyzer.Global;
using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;
using Sc2ReplayAnalyzer.Json.protocol95299.Versioned;
using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using BitPacked = Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;
using GameSDetails = Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions.GameSDetails;
using Versioned = Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;

namespace Sc2ReplayAnalyzer.Decoder;

public class ReplayDecoder
{
    private Dictionary<string, ArraySegment<byte>> _listingFiles;   
    private BitPackedProtocolParserFactory _bitPackedProtocolParserFactory;
    private VersionedProtocolParserFactory _versionedProtocolParserFactory;

    public int CorruptedReplays = 0;
    public long CurrentBuildNumber = 0;

    public Sc2Replay DecodeReplay(Stream fileStream, string fileName = null)
    {
        var mpqArchive = new MPQReader(fileStream).Read();

        _listingFiles = mpqArchive.ListingFiles;

        var header = ParseHeader(mpqArchive.MPQUserData);

        CurrentBuildNumber = header.m_dataBuildNum;

        _bitPackedProtocolParserFactory = new BitPackedProtocolParserFactory(CurrentBuildNumber);
        _versionedProtocolParserFactory = new VersionedProtocolParserFactory(CurrentBuildNumber);

        var replayData = new Sc2ReplayData
        {
            FileName = fileName,
            Header = header,
            Attributes = ParseGlobalAttributes(),
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

        return DecodeReplay(fileStream, Path.GetFileNameWithoutExtension(path));
    }

    private ReplaySHeader ParseHeader(MPQUserData userData)
    {
        using var binaryReader = new BinaryReader(new MemoryStream(userData.Content));
        var parser = new VersionedProtocolParser(binaryReader);

        return parser.Parse_ReplaySHeader();
    }

    private  ReplayAttributes ParseGlobalAttributes() =>
        new AttributeEventParser().ParseGlobalAttributes(_listingFiles[MPQListingFileConstant.AttributeEvents].Array);

    private ReplayMetadata ParseMetaData()
    {
        using var stream = GetFileMemoryStream(_listingFiles[MPQListingFileConstant.GameMetaData]);
        return JsonSerializer.Deserialize<ReplayMetadata>(stream);
    }

    private ReplaySInitData ParseReplayInitData()
    {
        using var stream = GetFileMemoryStream(_listingFiles[MPQListingFileConstant.InitData]);
        using var reader = new BinaryReader(stream);

        var bitPackedParser = _bitPackedProtocolParserFactory.Create(reader);

        var result = bitPackedParser.Parse_ReplaySInitData();

        var authorName = result.m_syncLobbyState.m_gameDescription.m_mapAuthorName.Value.ReadStringBytes();

        return result;
      
    }

    private IReadOnlyList<MessageEventTriplet> ParseMessageEvents()
    {
        using var stream = GetFileMemoryStream(_listingFiles[MPQListingFileConstant.MessageEvents]);
        using var reader = new BinaryReader(stream);

        var bitPackedParser = _bitPackedProtocolParserFactory.Create(reader);
        var result = new List<MessageEventTriplet>(256); // Pre-allocate typical capacity

        long gameLoop = 0;
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            result.Add(ParseMessageEventTriplet(bitPackedParser, ref gameLoop));
        }

        return result;
    }

    private GameSDetails ParseReplayDetails()
    {
        using var stream = GetFileMemoryStream(_listingFiles[MPQListingFileConstant.Details]);
        using var reader = new BinaryReader(stream);

        var versionedParser = _versionedProtocolParserFactory.Create(reader);

        var owo = versionedParser.Parse_GameSDetails();

        return owo;
    }

    private IReadOnlyList<GameEventTriplet> ParseGameEvents()
    {
        using var stream = GetFileMemoryStream(_listingFiles[MPQListingFileConstant.GameEvents]);
        using var reader = new BinaryReader(stream);
        var bitPackedParser = _bitPackedProtocolParserFactory.Create(reader);

        var result = new List<GameEventTriplet>(512); // Pre-allocate typical capacity
        long gameLoop = 0;

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            result.Add(ParseGameEventTriplet(bitPackedParser, ref gameLoop));
        }

        return result;
    }

    private IReadOnlyList<TrackerEventPair> ParseTrackerEvents()
    {
        using var stream = GetFileMemoryStream(_listingFiles[MPQListingFileConstant.TrackerEvents]);
        using var reader = new BinaryReader(stream);
        var versionedParser = _versionedProtocolParserFactory.Create(reader);
        var result = new List<TrackerEventPair>(512); // Pre-allocate typical capacity

        try
        {
            long gameLoop = 0;

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                result.Add(ParseEventPair(versionedParser, ref gameLoop));
            }
        }
        catch(ReplayCorruptedException)
        {
            ++CorruptedReplays;
        }

        return result;
    }

    private MemoryStream GetFileMemoryStream(ArraySegment<byte> data) => new(data.Array, data.Offset, data.Count, false);

    private TrackerEventPair ParseEventPair(IVersionedProtocolParser trackerParser, ref long gameLoop)
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
        gameLoop += deltaValue;

        if (eventID is ReplayTrackerEEventId_e_unknown)
        {
            throw new ReplayCorruptedException("Unknown event id.");
        }

        return new TrackerEventPair
        {
            Delta = gameLoop,
            TrackerEventID = eventID
        };
    }

    private GameEventTriplet ParseGameEventTriplet(IBitPackedProtocolParser bitPackedParser, ref long gameLoop)
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

        gameLoop += realDelta;
        bitPackedParser.byte_align();

        return new GameEventTriplet
        {
            Delta = gameLoop,
            UserID = gameUserID.m_userId,
            EventID = eventID
        };
    }

    private MessageEventTriplet ParseMessageEventTriplet(IBitPackedProtocolParser bitPackedParser, ref long gameLoop)
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

        gameLoop += realDelta;
        bitPackedParser.byte_align();

        return new MessageEventTriplet
        {
            Delta = gameLoop,
            UserID = gameUserID.m_userId,
            EventID = eventID
        };
    }
}
