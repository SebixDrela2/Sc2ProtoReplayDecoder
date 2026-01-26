using MPQArchive.MPQ;
//using Sc2ReplayAnalyzer.Json.protocol95299;
using Sc2ReplayAnalyzer.Tokenizer;
using System.Reflection.PortableExecutable;
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

        //var parser = new ProtocolParser(binaryReader);
        //var header = parser.Parse_ReplaySHeader();

        //var trackerListingFile = mpqArchive.ListingFiles;
        //ParseTrackerEvents(trackerListingFile);
    }

    //private void ParseTrackerEvents(Dictionary<string, byte[]> listingFiles)
    //{
    //    using var reader = new BinaryReader(new MemoryStream(listingFiles["replay.tracker.events"]));
    //    using var trackerParser = new ProtocolParser(reader);

    //    while (reader.BaseStream.Position < reader.BaseStream.Length)
    //    {
    //        var eventPair = ParseEventPair(trackerParser);

    //        if (eventPair.TrackerEventID is ReplayTrackerEEventId_e_playerSetup a)
    //        {
    //            var setUp = trackerParser.Parse_ReplayTrackerSPlayerSetupEvent();
    //        }
    //    }
    //}

    //private EventPair ParseEventPair(ProtocolParser trackerParser)
    //{
    //    var delta = trackerParser.Parse_SVarUint32();
    //    var eventID = trackerParser.Parse_ReplayTrackerEEventId();

    //    uint deltaValue = delta switch
    //    {
    //        m_uint6 val => val.Value,
    //        m_uint14 val => val.Value,
    //        m_uint22 val => val.Value,
    //        m_uint32 val => val.Value,
    //        _ => throw new NotImplementedException(),
    //    };

    //    return new EventPair
    //    {
    //        Delta = deltaValue,
    //        TrackerEventID = eventID
    //    };
    //}

    //private record class EventPair
    //{
    //    public ReplayTrackerEEventId TrackerEventID;
    //    public uint Delta;
    //}
}
