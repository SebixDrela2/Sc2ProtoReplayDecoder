global using u8 = byte;
global using i8 = sbyte;
global using u16 = ushort;
global using i16 = short;
global using u32 = uint;
global using i32 = int;
global using u64 = ulong;
global using i64 = long;
global using f16 = System.Half;
global using f32 = float;
global using f64 = double;
global using usize = nuint;
global using ssize = nint;

global using static Sc2ReplayAnalyzer.Global.Global;
using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;
namespace Sc2ReplayAnalyzer.Global;

public struct NoneValue;

public class Global
{
    public const int MaxExpectedProtocolNotInclusive = 100000;
}

// Map owners can have their own tracker events which we obviously want to skip.
public record ReplayTrackerEEventId_e_unknown() : ReplayTrackerEEventId;

public class ReplayCorruptedException(string message) : Exception(message);