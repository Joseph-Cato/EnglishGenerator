// namespace EnglishGenerator.Core.ResultTypes;

// public interface Result<T>
// {
// public TResult UnwrapOr<TResult>(Func<T, TResult> onSuccess, Func<TResult> onFailure);
// }

// public sealed class Ok<T> : IResult<T>
// {
// private readonly T _value;

// private Ok(T value)
// {
// _value = value;
// }

// public TResult UnwrapOr<TResult>(Func<T, TResult> onSuccess, Func<TResult> _)
// {
// return onSuccess(_value);
// }

// public TResult 
// }