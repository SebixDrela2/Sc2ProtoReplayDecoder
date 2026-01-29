using MPQArchive.MPQ;
using Sc2ReplayAnalyzer.Json.MetaData;
using Sc2ReplayAnalyzer.Json.protocol90870.BitPacked;
using Sc2ReplayAnalyzer.Json.protocol90870.Versioned;
using Sc2ReplayAnalyzer.Tokenizer;
using System.Diagnostics;
using System.Text;
namespace Sc2ReplayAnalyzer.Decoder;

public class Sc2ReplayDecoder(string path)
{
    private readonly Sc2JsonProvider _provider = new Sc2JsonProvider();

    private Dictionary<string, byte[]> _listingFiles;
    public void Decode()
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

        try
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var messageTriples = ParseMessageEventTriplet(bitPackedParser, info);
                var debug = $"Event#{_counter} Delta: {messageTriples.Delta} Event:{messageTriples.EventID.GetType().Name.ToUpper()}";

                info.Add(debug);
            }
        }
        catch(Exception ex)
        {
            throw;
        }
        finally
        {
            
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

        try
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var gameTriples = ParseGameEventTriplet(bitPackedParser, info);
                var debug = $"Event#{_counter} Delta: {gameTriples.Delta} Event:{gameTriples.EventID.GetType().Name.ToUpper()}";

                info.Add(debug);
            }
        }
        catch
        {
            
        }
    }

    private void ParseTrackerEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.tracker.events"]));
        var versionedParser = new VersionedProtocolParser(reader);

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            var eventPair = ParseEventPair(versionedParser);

            if (eventPair.TrackerEventID is ReplayTrackerEEventId_e_unitBorn born)
            {
                var sUpgradeEvent = born.Value;

                //Console.WriteLine($"{Encoding.UTF8.GetString([.. sUpgradeEvent.m_unitTypeName])} {sUpgradeEvent.m_upkeepPlayerId} {sUpgradeEvent.m_unitTagIndex}");
            }
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

    private static int _counter = 0;
    private static int _operation = 0;

    private GameEventTriplet ParseGameEventTriplet(BitPackedProtocolParser bitPackedParser, List<string> info)
    {
        var delta = bitPackedParser.Parse_SVarUint32();
        LogLines(bitPackedParser, info);

        var gameUserID = bitPackedParser.Parse_ReplaySGameUserId();
        LogLines(bitPackedParser, info);

        var eventID = bitPackedParser.Parse_GameEEventId();
        LogLines(bitPackedParser, info);

        var realDelta = delta switch
        {
            Json.protocol90870.BitPacked.m_uint6 val => val.Value.Value,
            Json.protocol90870.BitPacked.m_uint14 val => val.Value.Value,
            Json.protocol90870.BitPacked.m_uint22 val => val.Value.Value,
            Json.protocol90870.BitPacked.m_uint32 val => val.Value.Value,
            _ => throw new NotImplementedException(),
        };

        bitPackedParser.byte_align();

        _counter++;

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
        LogLines(bitPackedParser, info);

        var gameUserID = bitPackedParser.Parse_ReplaySGameUserId();
        LogLines(bitPackedParser, info);

        var eventID = bitPackedParser.Parse_GameEMessageId();
        LogLines(bitPackedParser, info);

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

    private void LogLines(BitPackedProtocolParser bitPacked, List<string> info)
    {
        var operation = _operation;
        var rustSize = bitPacked.RustSize;
        var available = bitPacked.AvailableBits;
        var offset = 8 - available;

        var debug = $"Op:{operation}: (RS:{rustSize}, OS:{offset})";

        //Console.WriteLine(debug);    

        _operation++;

        if (_operation == 35)
        {

        }
    }

    private record class EventPair
    {
        public uint Delta;
        public ReplayTrackerEEventId TrackerEventID;
    }

    private record class GameEventTriplet
    {
        public long Delta;
        public long UserID;
        public GameEEventId EventID;
    }

    private record class MessageEventTriplet
    {
        public long Delta;
        public long UserID;
        public GameEMessageId EventID;
    }
}
