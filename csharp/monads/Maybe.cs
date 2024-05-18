public sealed class Maybe<T> : Monad<T>
{
    private readonly T value;

    public Maybe(T someValue!!) : base(someValue)
    {
        // `someValue!!` adds an implicit check:
        // if (someValue == null)
        //    throw new ArgumentNullException(nameof(someValue));
        this.value = someValue;
    }

    private Maybe() : base(default)
    {
    }

    public Maybe<R> Bind<R>(Func<T, Maybe<R>> f) where R : class
    {
        return value is null ? Maybe<R>.None() : f(value);
    }

    public static Maybe<T> Nothing => new Maybe<T>();
    public static Maybe<T> Just(T value) => new Maybe<T>(someValue);
}
