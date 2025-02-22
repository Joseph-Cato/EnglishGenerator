namespace EnglishGenerator.Core.OptionTypes;

public class None<T> : IOption<T>
{
    public TResult Match<TResult>(Func<T, TResult> _, Func<TResult> onNone)
    {
        return onNone();
    }

    public IOption<TResult> Bind<TResult>(Func<T, IOption<TResult>> function)
    {
        return new None<TResult>();
    }

    public IOption<TResult> Map<TResult>(Func<T, TResult> function)
    {
        return new None<TResult>();
    }

    public T Or(T aDefault)
    {
        return aDefault;
    }
}