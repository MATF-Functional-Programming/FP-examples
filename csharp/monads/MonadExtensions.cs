public static class MonadExtensions
{
    public static Monad<T> Return<T>(this T instance) => new Monad<T>(instance);
}

