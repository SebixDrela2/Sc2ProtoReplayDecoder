using MPQArchive.MPQ;
using Sc2ReplayAnalyzer.Json.protocol95299.BitPacked;
using Sc2ReplayAnalyzer.Json.protocol95299.Versioned;
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
        using var fileStream = File.Open(path, FileMode.Open);
        var mpqArchive = new MPQReader(fileStream).Read();
        var userData = mpqArchive.MPQUserData;

        using var binaryReader = new BinaryReader(new MemoryStream(mpqArchive.MPQUserData.Content));

        var parser = new VersionedProtocolParser(binaryReader);
        var header = parser.Parse_ReplaySHeader();

        _listingFiles = mpqArchive.ListingFiles;

        ParseReplayEvents();
        //ParseTrackerEvents(trackerListingFile);
        //ParseGameEvents(trackerListingFile);
    }

    private void ParseReplayEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.details"]));

        var versionedParser = new VersionedProtocolParser(reader);
        var gameEvents = versionedParser.Parse_GameSDetails();
    }

    private void ParseGameEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.game.events"]));

        var bitPackedParser = new BitPackedProtocolParser(reader);

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            var gameTriples = ParseEventTriplet(bitPackedParser);

            Console.WriteLine($"Event#{_counter} Delta: {gameTriples.Delta} Event:{gameTriples.EventID.GetType().Name.ToUpper()}");
        }
    }

    private void ParseTrackerEvents()
    {
        using var reader = new BinaryReader(new MemoryStream(_listingFiles["replay.tracker.events"]));
        var versionedParser = new VersionedProtocolParser(reader);

        var count = 0;

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            var eventPair = ParseEventPair(versionedParser);

            if (eventPair.TrackerEventID is ReplayTrackerEEventId_e_unitBorn born)
            {
                var sUpgradeEvent = born.Value;

                Console.WriteLine($"{Encoding.UTF8.GetString([.. sUpgradeEvent.m_unitTypeName])} {sUpgradeEvent.m_upkeepPlayerId} {sUpgradeEvent.m_unitTagIndex}");
            }
        }
    }

    private EventPair ParseEventPair(VersionedProtocolParser trackerParser)
    {
        var delta = trackerParser.Parse_SVarUint32();
        var eventID = trackerParser.Parse_ReplayTrackerEEventId();

        uint deltaValue = delta switch
        {
            Json.protocol95299.Versioned.m_uint6 val => val.Value,
            Json.protocol95299.Versioned.m_uint14 val => val.Value,
            Json.protocol95299.Versioned.m_uint22 val => val.Value,
            Json.protocol95299.Versioned.m_uint32 val => val.Value,
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

    private EventTriplet ParseEventTriplet(BitPackedProtocolParser bitPackedParser)
    {
        var delta = bitPackedParser.Parse_SVarUint32();
        var gameUserID = bitPackedParser.Parse_ReplaySGameUserId();
        var eventID = bitPackedParser.Parse_GameEEventId();

        var realDelta = delta switch
        {
            Json.protocol95299.BitPacked.m_uint6 val => val.Value.Value,
            Json.protocol95299.BitPacked.m_uint14 val => val.Value.Value,
            Json.protocol95299.BitPacked.m_uint22 val => val.Value.Value,
            Json.protocol95299.BitPacked.m_uint32 val => val.Value.Value,
            _ => throw new NotImplementedException(),
        };

        bitPackedParser.byte_align();

        return new EventTriplet
        {
            Delta = realDelta,
            UserID = gameUserID.m_userId,
            EventID = eventID
        };
    }

    private string DebugLines(BitPackedProtocolParser bitPacked)
    {
        var operation = _operation;
        var rustSize = bitPacked.RustSize;
        var available = bitPacked.AvailableBits;
        var offset = 8 - available;

        return $"Op:{operation}: (RS:{rustSize}, OS:{offset})";
    }

    private record class EventPair
    {
        public uint Delta;
        public ReplayTrackerEEventId TrackerEventID;
    }

    private record class EventTriplet
    {
        public long Delta;
        public long UserID;
        public GameEEventId EventID;
    }
}
