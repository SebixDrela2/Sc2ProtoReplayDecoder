using MPQArchive.MPQ;
using Sc2ReplayAnalyzer.Json.protocol95299.BitPacked;
using Sc2ReplayAnalyzer.Json.protocol95299.Versioned;
using Sc2ReplayAnalyzer.Tokenizer;
namespace Sc2ReplayAnalyzer.Decoder;

public class Sc2ReplayDecoder(string path)
{
    private readonly Sc2JsonProvider _provider = new Sc2JsonProvider();

    public void Decode()
    {
        using var fileStream = File.Open(path, FileMode.Open);
        var mpqArchive = new MPQReader(fileStream).Read();
        var userData = mpqArchive.MPQUserData;

        using var binaryReader = new BinaryReader(new MemoryStream(mpqArchive.MPQUserData.Content));

        var parser = new VersionedProtocolParser(binaryReader);
        var header = parser.Parse_ReplaySHeader();

        var trackerListingFile = mpqArchive.ListingFiles;

        //ParseTrackerEvents(trackerListingFile);
        ParseGameEvents(trackerListingFile);
    }

    private void ParseGameEvents(Dictionary<string, byte[]> listingFiles)
    {
        using var reader = new BinaryReader(new MemoryStream(listingFiles["replay.game.events"]));
        var bitPackedParser = new BitPackedProtocolParser(reader);

        var count = 0;
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            var gameTriples = ParseEventTriplet(bitPackedParser);

            Console.WriteLine($"Game{count++}" + gameTriples.EventID);
        }
    }

    private void ParseTrackerEvents(Dictionary<string, byte[]> listingFiles)
    {
        using var reader = new BinaryReader(new MemoryStream(listingFiles["replay.tracker.events"]));
        var versionedParser = new VersionedProtocolParser(reader);

        var count = 0;

        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            var eventPair = ParseEventPair(versionedParser);

            Console.WriteLine($"Tracker{count++}" + eventPair.TrackerEventID);
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
