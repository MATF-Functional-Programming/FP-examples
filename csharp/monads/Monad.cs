public abstract class Monad<T>
{
    // return
    public Monad(T instance)
    {
    }

    // >>=
    public abstract Monad<TO> Bind<TO>(Func<T, Monad<TO>> func);
}

