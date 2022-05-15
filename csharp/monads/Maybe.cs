public class Maybe<T> : Monad<T> where T : class
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

    public Maybe<TO> Bind<TO>(Func<T, Maybe<TO>> func) where TO : class
    {
        return value is not null ? func(value) : Maybe<TO>.None();
    }

    public static Maybe<T> None() => new Maybe<T>();
}
