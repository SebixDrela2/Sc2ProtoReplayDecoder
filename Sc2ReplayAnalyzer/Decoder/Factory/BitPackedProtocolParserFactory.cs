using Sc2ReplayAnalyzer.Json;

namespace Sc2ReplayAnalyzer.Decoder.Factory;

internal class BitPackedProtocolParserFactory(long protocolNumber)
{    
    private static readonly SortedDictionary<long, Func<BinaryReader, IBitPackedProtocolParser>> s_protocolCache = 
        new()
        {
            { 51702, r => new Json.protocol51702.BitPacked.BitPackedProtocolParser(r) },
            { 52910, r => new Json.protocol52910.BitPacked.BitPackedProtocolParser(r) },
            { 53644, r => new Json.protocol53644.BitPacked.BitPackedProtocolParser(r) },
            { 54518, r => new Json.protocol54518.BitPacked.BitPackedProtocolParser(r) },
            { 55505, r => new Json.protocol55505.BitPacked.BitPackedProtocolParser(r) },
            { 55958, r => new Json.protocol55958.BitPacked.BitPackedProtocolParser(r) },
            { 56787, r => new Json.protocol56787.BitPacked.BitPackedProtocolParser(r) },
            { 57507, r => new Json.protocol57507.BitPacked.BitPackedProtocolParser(r) },
            { 58400, r => new Json.protocol58400.BitPacked.BitPackedProtocolParser(r) },
            { 59587, r => new Json.protocol59587.BitPacked.BitPackedProtocolParser(r) },
            { 60196, r => new Json.protocol60196.BitPacked.BitPackedProtocolParser(r) },
            { 60321, r => new Json.protocol60321.BitPacked.BitPackedProtocolParser(r) },
            { 62347, r => new Json.protocol62347.BitPacked.BitPackedProtocolParser(r) },
            { 62848, r => new Json.protocol62848.BitPacked.BitPackedProtocolParser(r) },
            { 63454, r => new Json.protocol63454.BitPacked.BitPackedProtocolParser(r) },
            { 64469, r => new Json.protocol64469.BitPacked.BitPackedProtocolParser(r) },
            { 65094, r => new Json.protocol65094.BitPacked.BitPackedProtocolParser(r) },
            { 65384, r => new Json.protocol65384.BitPacked.BitPackedProtocolParser(r) },
            { 65895, r => new Json.protocol65895.BitPacked.BitPackedProtocolParser(r) },
            { 66668, r => new Json.protocol66668.BitPacked.BitPackedProtocolParser(r) },
            { 67188, r => new Json.protocol67188.BitPacked.BitPackedProtocolParser(r) },
            { 67926, r => new Json.protocol67926.BitPacked.BitPackedProtocolParser(r) },
            { 69232, r => new Json.protocol69232.BitPacked.BitPackedProtocolParser(r) },
            { 70154, r => new Json.protocol70154.BitPacked.BitPackedProtocolParser(r) },
            { 71061, r => new Json.protocol71061.BitPacked.BitPackedProtocolParser(r) },
            { 71523, r => new Json.protocol71523.BitPacked.BitPackedProtocolParser(r) },
            { 71663, r => new Json.protocol71663.BitPacked.BitPackedProtocolParser(r) },
            { 72282, r => new Json.protocol72282.BitPacked.BitPackedProtocolParser(r) },
            { 73286, r => new Json.protocol73286.BitPacked.BitPackedProtocolParser(r) },
            { 73559, r => new Json.protocol73559.BitPacked.BitPackedProtocolParser(r) },
            { 73620, r => new Json.protocol73620.BitPacked.BitPackedProtocolParser(r) },
            { 74071, r => new Json.protocol74071.BitPacked.BitPackedProtocolParser(r) },
            { 74456, r => new Json.protocol74456.BitPacked.BitPackedProtocolParser(r) },
            { 74741, r => new Json.protocol74741.BitPacked.BitPackedProtocolParser(r) },
            { 75025, r => new Json.protocol75025.BitPacked.BitPackedProtocolParser(r) },
            { 75689, r => new Json.protocol75689.BitPacked.BitPackedProtocolParser(r) },
            { 75800, r => new Json.protocol75800.BitPacked.BitPackedProtocolParser(r) },
            { 76052, r => new Json.protocol76052.BitPacked.BitPackedProtocolParser(r) },
            { 76114, r => new Json.protocol76114.BitPacked.BitPackedProtocolParser(r) },
            { 77379, r => new Json.protocol77379.BitPacked.BitPackedProtocolParser(r) },
            { 77535, r => new Json.protocol77535.BitPacked.BitPackedProtocolParser(r) },
            { 77661, r => new Json.protocol77661.BitPacked.BitPackedProtocolParser(r) },
            { 78285, r => new Json.protocol78285.BitPacked.BitPackedProtocolParser(r) },
            { 80669, r => new Json.protocol80669.BitPacked.BitPackedProtocolParser(r) },
            { 80949, r => new Json.protocol80949.BitPacked.BitPackedProtocolParser(r) },
            { 81009, r => new Json.protocol81009.BitPacked.BitPackedProtocolParser(r) },
            { 82457, r => new Json.protocol82457.BitPacked.BitPackedProtocolParser(r) },
            { 82893, r => new Json.protocol82893.BitPacked.BitPackedProtocolParser(r) },
            { 83830, r => new Json.protocol83830.BitPacked.BitPackedProtocolParser(r) },
            { 84643, r => new Json.protocol84643.BitPacked.BitPackedProtocolParser(r) },
            { 86383, r => new Json.protocol86383.BitPacked.BitPackedProtocolParser(r) },
            { 87702, r => new Json.protocol87702.BitPacked.BitPackedProtocolParser(r) },
            { 88500, r => new Json.protocol88500.BitPacked.BitPackedProtocolParser(r) },
            { 89634, r => new Json.protocol89634.BitPacked.BitPackedProtocolParser(r) },
            { 89720, r => new Json.protocol89720.BitPacked.BitPackedProtocolParser(r) },
            { 90136, r => new Json.protocol90136.BitPacked.BitPackedProtocolParser(r) },
            { 90779, r => new Json.protocol90779.BitPacked.BitPackedProtocolParser(r) },
            { 90870, r => new Json.protocol90870.BitPacked.BitPackedProtocolParser(r) },
            { 91115, r => new Json.protocol91115.BitPacked.BitPackedProtocolParser(r) },
            { 92028, r => new Json.protocol92028.BitPacked.BitPackedProtocolParser(r) },
            { 92174, r => new Json.protocol92174.BitPacked.BitPackedProtocolParser(r) },
            { 92440, r => new Json.protocol92440.BitPacked.BitPackedProtocolParser(r) },
            { 93272, r => new Json.protocol93272.BitPacked.BitPackedProtocolParser(r) },
            { 93333, r => new Json.protocol93333.BitPacked.BitPackedProtocolParser(r) },
            { 95248, r => new Json.protocol95248.BitPacked.BitPackedProtocolParser(r) },
            { 95299, r => new Json.protocol95299.BitPacked.BitPackedProtocolParser(r) },
        };

    public IBitPackedProtocolParser Create(BinaryReader reader)
    {
        // Find the protocol handler by finding the closest protocol number that is <= protocolNumber
        var foundKey = 0L;
        foreach (var key in s_protocolCache.Keys)
        {
            if (key <= protocolNumber)
                foundKey = key;
            else
                break;
        }

        if (foundKey == 0)
        {
            throw new NotSupportedException($"Not supported protocol: {protocolNumber}");
        }

        return s_protocolCache[foundKey](reader);
    }
}
