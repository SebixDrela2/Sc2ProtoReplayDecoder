using Sc2ReplayAnalyzer.Global;
using System.Text;

namespace Sc2ReplayAnalyzer.Decoder.Parser;

internal static partial class Parse
{
    internal static string GetKind(this object obj)
    {
        var typeName = obj.GetType().Name;
        var kind = typeName.Split("_e_")[1];

        return char.ToUpper(kind[0]) + kind[1..];
    }

    internal static long ReadLong(this Option<long> option)
    {
        if (option.HasValue)
        {
            return option.Value;
        }

        return -1;
    }

    internal static int ReadInt(this Option<int> option)
    {
        if (option.HasValue)
        {
            return option.Value;
        }

        return -1;
    }

    internal static bool ReadBool(this Option<bool> option)
    {
        if (option.HasValue)
        {
            return option.Value;
        }

        return false;
    }

    internal static string ReadStringBytes(this Option<byte[]> option)
    {
        if (option.HasValue)
        {
            return Encoding.UTF8.GetString([.. option.Value]);
        }

        return null;
    }

    internal static string ReadStringBytes(this List<byte> bytes)
    {
        if (bytes is not null)
        {
            return Encoding.UTF8.GetString([.. bytes]);
        }

        return null;
    }
}
