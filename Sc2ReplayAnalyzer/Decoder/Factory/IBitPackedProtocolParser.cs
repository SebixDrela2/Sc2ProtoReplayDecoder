using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;

namespace Sc2ReplayAnalyzer.Decoder.Factory;

internal interface IBitPackedProtocolParser
{
    ReplaySInitData Parse_ReplaySInitData();

    ReplaySGameUserId Parse_ReplaySGameUserId();

    SVarUint32 Parse_SVarUint32();

    GameEMessageId Parse_GameEMessageId();

    GameEEventId Parse_GameEEventId();

    void byte_align();

    int RustSize { get; }

    int AvailableBits { get; }
}
