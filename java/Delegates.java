import java.util.function.*;

public class Delegates {

    public static void main(String[] args) {

        // Function<T, R>    --->    R f(T)  aka  T -> R
        Function<String, Integer> function = s -> s.length();

        // Predicate<T>      --->    bool f(T)  aka  T -> Bool
        // Special types: IntPredicate, LongPredicate ...
        Predicate<String> predicate = s -> s.isEmpty();

        // Supplier<T>       --->    T f(void)  aka  () -> T
        Supplier<String> supplier = () -> "Hello!";
        
        // Consumer<T>       --->    void f(T)  aka  T -> ()
        Consumer<String> consumer = s -> System.out.println(s);

        // Runnable          --->    void f(void)  aka  () -> ()
        Runnable runnable = () -> {
            System.out.println("Hello!");
        };

        // BiFunction<T1, T2, R>   --->  R f(T1, T2)  aka  T1 -> T2 -> R
        // Similar for BiSupplier, BiConsumer...
        BiFunction<String, String, Integer> biFunction = (s1, s2) -> s1.length() + s2.length();

        // FunctionalInterface<T>
        // method: void apply(T)

    }

}
