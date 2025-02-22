namespace EnglishGenerator.Core.OptionTypes;

public interface IOption<T>
{
    TResult Match<TResult>(Func<T, TResult> onSome, Func<TResult> onNone);
    IOption<TResult> Bind<TResult>(Func<T, IOption<TResult>> function);
    IOption<TResult> Map<TResult>(Func<T, TResult> function);
    T Or(T aDefault);
}