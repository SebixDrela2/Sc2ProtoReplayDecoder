namespace Sc2ReplayAnalyzer.Global;

public struct Option<T>
{
    public bool HasValue;
    public T Value;

    public static Option<T> Some(T value) => new Option<T>
    {
        HasValue = true,
        Value = value
    };

    public readonly T DefaultIfNone(T defaultValue) => HasValue ? Value : defaultValue;
    public readonly T DefaultIfNone() => default;

    public readonly void Deconstruct(out bool hasValue, out T value) => (hasValue, value) = (HasValue, Value);

    public static implicit operator Option<T>(NoneValue value) => None;
    public static readonly Option<T> None = default;
}

public static class Option
{
    public static T OkOrReturnMissingFieldErr<T>(Option<T> option)
    {
        if (!option.HasValue)
        {
            return default;
        }

        return option.Value;
    }

    public static Option<T> Some<T>(T value) => new Option<T>
    {
        HasValue = true,
        Value = value
    };

    public static readonly NoneValue None = default;
}

