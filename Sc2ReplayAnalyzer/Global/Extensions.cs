using System.Numerics;

namespace Sc2ReplayAnalyzer.Global;

public static class ProtocolConversion<TResult>
{

}

public static class Extensions
{
    extension<TResult>(ProtocolConversion<TResult>)
        where TResult : unmanaged, IBinaryInteger<TResult>
    {
        public static TResult From<TFrom>(TFrom source)
            where TFrom : unmanaged, IBinaryInteger<TFrom> => TResult.CreateTruncating<TFrom>(source);
    }
}
