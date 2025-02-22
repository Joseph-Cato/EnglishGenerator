namespace EnglishGenerator.Core.ResultTypes;

public record Result<T, E>
{
    private readonly bool _success;
    private readonly T _value;
    private readonly E _error;

    public bool IsOk => _success;

    public static implicit operator Result<T, E>(T value) => Ok(value);
    public static implicit operator Result<T, E>(E error) => Fail(error);

    public static Result<T, E> Ok(T value)
    {
        return new(value, default, true);
    }

    public static Result<T, E> Fail(E error)
    {
        return new(default, error, false);
    }

    public R Match<R>(
        Func<T, R> success,
        Func<E, R> failure) =>
        _success ? success(_value) : failure(_error);

    private Result(T value, E error, bool success)
    {
        _value = value;
        _error = error;
        _success = success;
    }
}