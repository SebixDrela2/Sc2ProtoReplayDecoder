namespace Sc2ReplayAnalyzer.Global;

public static class ProtocolConversion<TResult>
{
    public static bool TryFrom<TFrom>(TFrom source, out TResult result)
    {
        result = default;

        if (source == null)
        {
            return false;
        }

        if (source is TResult)
        {
            result = (TResult)(object)source;
            return true;
        }

        try
        {
            var underlyingType = Nullable.GetUnderlyingType(typeof(TResult));
            var targetType = underlyingType ?? typeof(TResult);

            if (targetType == typeof(string))
            {
                result = (TResult)(object)source.ToString();
                return true;
            }

            if (source is IConvertible)
            {
                result = (TResult)Convert.ChangeType(source, targetType);
                return true;
            }
        }
        catch
        {
            return false;
        }

        return false;
    }

    //public static TResult From<TFrom>(TFrom source)
    //{
    //    if (!TryFrom(source, out var result))
    //    {
    //        throw new InvalidCastException($"Invalid cast");
    //    }

    //    return result;
    //}
}
