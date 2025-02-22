namespace EnglishGenerator.Core.OptionTypes;

public class Some<T> : IOption<T>
{
    private readonly T _data;

    private Some(T data)
    {
        _data = data;
    }

    public static IOption<T> Of(T data) => new Some<T>(data);

    public TResult Match<TResult>(Func<T, TResult> onSome, Func<TResult> _)
    {
        return onSome(_data);
    }

    public IOption<TResult> Bind<TResult>(Func<T, IOption<TResult>> function)
    {
        return function(_data);
    }

    public IOption<TResult> Map<TResult>(Func<T, TResult> function)
    {
        return new Some<TResult>(function(_data));
    }

    public T Or(T aDefault)
    {
        return _data;
    }
}