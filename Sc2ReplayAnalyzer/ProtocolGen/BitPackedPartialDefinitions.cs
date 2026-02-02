namespace Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;

partial class uint32
{
    public static implicit operator long(uint32 self) => self.Value;

    public static implicit operator uint32(long value) => new() { Value = value };
}
