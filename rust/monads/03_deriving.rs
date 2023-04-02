#[derive(Functor(map), Monad(Some, and_then))]
enum Option { ... }

#[derive(Functor(map), Monad(once, flat_map))]
trait Iterator { ... }

