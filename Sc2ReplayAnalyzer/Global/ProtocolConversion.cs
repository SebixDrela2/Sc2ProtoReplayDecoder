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
namespace Sc2ReplayAnalyzer.Global;

public struct NoneValue;

public class Global
{
    public const int MaxExpectedProtocolNotInclusive = 100000;
}