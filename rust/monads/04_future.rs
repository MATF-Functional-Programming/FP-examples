impl<A, E, R: Future<Item = A, E>> Functor<A> for R {
    type Map<_, F> = future::Map<Self, F>;

    trait MapFn<T, U> = FnOnce(T) -> U;

    fn map<B, F: FnOnce(A) -> B>(self, f: F) -> future::Map<Self, F> {
        self.map(f)
    }
}

impl<A, E, R: Future<Item = A, E>> Monad<A> for R {
    trait SelfTrait<T> = Future<Item = T, E>;

    // Unit
    type Unit<T> = Ready<T>;

    fn unit(a: A) -> Ready<A> {
        future::ready(a)
    }

    // Bind
    type Bind<T, F> = AndThen<Self, T, F>;

    trait BindFn<T, U> = FnOnce(T) -> U;

    fn bind<B, MB: Future<Item = B, E>, F: FnOnce(A) -> B>(self, f: F) -> AndThen<B, F> {
        self.and_then(f)
    }
}

