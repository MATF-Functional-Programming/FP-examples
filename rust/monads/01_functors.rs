trait Functor<A> {
    type Map<T, F>: Functor<T>;

    trait MapFn<T, U>;

    fn map<B, F: Self::MapFn<A, B>>(Self, F) -> Self::Map<B, F>;
}

// Implementing `Functor` for a type.
impl<A> Functor<A> for Option<A> {
    type Map<T, F> = Option<T>;

    trait MapFn<T, U> = FnOnce(T) -> U;

    fn map<B, F: FnOnce(A) -> B>(self, f: F) -> Option<B> {
        self.map(f)
    }
}

// Implementing `Functor` for a trait.
impl<A, I: Iterator<Item = A>> Functor<A> for I {
    type Map<T, F> = iter::Map<T, F>;

    trait MapFn<T, U> = FnMut(T) -> U;

    fn map<B, F: FnMut(A) -> B>(self, f: F) -> iter::Map<B, F> {
        self.map(f)
    }
}

trait Applicative<A>: Functor<A> {
    trait SelfTrait<T>;

    // Unit
    fn unit(A) -> Self;

    // Apply
    type Apply<T, F>: Applicative<T>;

    trait BindFn<T, U>;

    fn apply<B, F: BindFn<A, B>, T: SelfTrait<F>>(T, Self) -> Apply<B, T>;
}

