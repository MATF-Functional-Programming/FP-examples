public abstract class Monad<T>
{
    // return
    public Monad(T instance)
    {
    }

    // >>=
    public abstract Monad<R> Bind<R>(Func<T, Monad<R>> func);
}

