namespace EnglishGenerator.Core.ResultTypes;

public record Result<TT, TE>
{
    private readonly bool _success;
    private readonly TT _value;
    private readonly TE _error;

    public bool IsOk => _success;

    public static implicit operator Result<TT, TE>(TT value) => Ok(value);
    public static implicit operator Result<TT, TE>(TE error) => Fail(error);

    public static Result<TT, TE> Ok(TT value)
    {
        return new(value, default!, true);
    }

    public static Result<TT, TE> Fail(TE error)
    {
        return new(default!, error, false);
    }

    public TR Match<TR>(
        Func<TT, TR> success,
        Func<TE, TR> failure) =>
        _success ? success(_value) : failure(_error);

    private Result(TT value, TE error, bool success)
    {
        _value = value;
        _error = error;
        _success = success;
    }
}