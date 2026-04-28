namespace Sc2ReplayAnalyzer.Decoder.Factory;

internal class VersionedProtocolParserFactory(long protocolNumber)
{
    private static readonly SortedDictionary<long, Func<BinaryReader, IVersionedProtocolParser>> s_protocolCache = 
        new()
        {
            { 51702, r => new Json.protocol51702.Versioned.VersionedProtocolParser(r) },
            { 52910, r => new Json.protocol52910.Versioned.VersionedProtocolParser(r) },
            { 53644, r => new Json.protocol53644.Versioned.VersionedProtocolParser(r) },
            { 54518, r => new Json.protocol54518.Versioned.VersionedProtocolParser(r) },
            { 55505, r => new Json.protocol55505.Versioned.VersionedProtocolParser(r) },
            { 55958, r => new Json.protocol55958.Versioned.VersionedProtocolParser(r) },
            { 56787, r => new Json.protocol56787.Versioned.VersionedProtocolParser(r) },
            { 57507, r => new Json.protocol57507.Versioned.VersionedProtocolParser(r) },
            { 58400, r => new Json.protocol58400.Versioned.VersionedProtocolParser(r) },
            { 59587, r => new Json.protocol59587.Versioned.VersionedProtocolParser(r) },
            { 60196, r => new Json.protocol60196.Versioned.VersionedProtocolParser(r) },
            { 60321, r => new Json.protocol60321.Versioned.VersionedProtocolParser(r) },
            { 62347, r => new Json.protocol62347.Versioned.VersionedProtocolParser(r) },
            { 62848, r => new Json.protocol62848.Versioned.VersionedProtocolParser(r) },
            { 63454, r => new Json.protocol63454.Versioned.VersionedProtocolParser(r) },
            { 64469, r => new Json.protocol64469.Versioned.VersionedProtocolParser(r) },
            { 65094, r => new Json.protocol65094.Versioned.VersionedProtocolParser(r) },
            { 65384, r => new Json.protocol65384.Versioned.VersionedProtocolParser(r) },
            { 65895, r => new Json.protocol65895.Versioned.VersionedProtocolParser(r) },
            { 66668, r => new Json.protocol66668.Versioned.VersionedProtocolParser(r) },
            { 67188, r => new Json.protocol67188.Versioned.VersionedProtocolParser(r) },
            { 67926, r => new Json.protocol67926.Versioned.VersionedProtocolParser(r) },
            { 69232, r => new Json.protocol69232.Versioned.VersionedProtocolParser(r) },
            { 70154, r => new Json.protocol70154.Versioned.VersionedProtocolParser(r) },
            { 71061, r => new Json.protocol71061.Versioned.VersionedProtocolParser(r) },
            { 71523, r => new Json.protocol71523.Versioned.VersionedProtocolParser(r) },
            { 71663, r => new Json.protocol71663.Versioned.VersionedProtocolParser(r) },
            { 72282, r => new Json.protocol72282.Versioned.VersionedProtocolParser(r) },
            { 73286, r => new Json.protocol73286.Versioned.VersionedProtocolParser(r) },
            { 73559, r => new Json.protocol73559.Versioned.VersionedProtocolParser(r) },
            { 73620, r => new Json.protocol73620.Versioned.VersionedProtocolParser(r) },
            { 74071, r => new Json.protocol74071.Versioned.VersionedProtocolParser(r) },
            { 74456, r => new Json.protocol74456.Versioned.VersionedProtocolParser(r) },
            { 74741, r => new Json.protocol74741.Versioned.VersionedProtocolParser(r) },
            { 75025, r => new Json.protocol75025.Versioned.VersionedProtocolParser(r) },
            { 75689, r => new Json.protocol75689.Versioned.VersionedProtocolParser(r) },
            { 75800, r => new Json.protocol75800.Versioned.VersionedProtocolParser(r) },
            { 76052, r => new Json.protocol76052.Versioned.VersionedProtocolParser(r) },
            { 76114, r => new Json.protocol76114.Versioned.VersionedProtocolParser(r) },
            { 77379, r => new Json.protocol77379.Versioned.VersionedProtocolParser(r) },
            { 77535, r => new Json.protocol77535.Versioned.VersionedProtocolParser(r) },
            { 77661, r => new Json.protocol77661.Versioned.VersionedProtocolParser(r) },
            { 78285, r => new Json.protocol78285.Versioned.VersionedProtocolParser(r) },
            { 80669, r => new Json.protocol80669.Versioned.VersionedProtocolParser(r) },
            { 80949, r => new Json.protocol80949.Versioned.VersionedProtocolParser(r) },
            { 81009, r => new Json.protocol81009.Versioned.VersionedProtocolParser(r) },
            { 82457, r => new Json.protocol82457.Versioned.VersionedProtocolParser(r) },
            { 82893, r => new Json.protocol82893.Versioned.VersionedProtocolParser(r) },
            { 83830, r => new Json.protocol83830.Versioned.VersionedProtocolParser(r) },
            { 84643, r => new Json.protocol84643.Versioned.VersionedProtocolParser(r) },
            { 86383, r => new Json.protocol86383.Versioned.VersionedProtocolParser(r) },
            { 87702, r => new Json.protocol87702.Versioned.VersionedProtocolParser(r) },
            { 88500, r => new Json.protocol88500.Versioned.VersionedProtocolParser(r) },
            { 89634, r => new Json.protocol89634.Versioned.VersionedProtocolParser(r) },
            { 89720, r => new Json.protocol89720.Versioned.VersionedProtocolParser(r) },
            { 90136, r => new Json.protocol90136.Versioned.VersionedProtocolParser(r) },
            { 90779, r => new Json.protocol90779.Versioned.VersionedProtocolParser(r) },
            { 90870, r => new Json.protocol90870.Versioned.VersionedProtocolParser(r) },
            { 91115, r => new Json.protocol91115.Versioned.VersionedProtocolParser(r) },
            { 92028, r => new Json.protocol92028.Versioned.VersionedProtocolParser(r) },
            { 92174, r => new Json.protocol92174.Versioned.VersionedProtocolParser(r) },
            { 92440, r => new Json.protocol92440.Versioned.VersionedProtocolParser(r) },
            { 93272, r => new Json.protocol93272.Versioned.VersionedProtocolParser(r) },
            { 93333, r => new Json.protocol93333.Versioned.VersionedProtocolParser(r) },
            { 95248, r => new Json.protocol95248.Versioned.VersionedProtocolParser(r) },
            { 95299, r => new Json.protocol95299.Versioned.VersionedProtocolParser(r) },
        };

    public IVersionedProtocolParser Create(BinaryReader reader)
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
