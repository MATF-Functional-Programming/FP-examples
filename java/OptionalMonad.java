import java.util.*;

public class OptionalMonad {

    public static void main(String[] args) {
        Optional<String> maybeString1 = Optional.of("non-empty Optional");
        Optional<String> maybeString2 = Optional.empty();

        nonFunctionalMethod(maybeString1);
        nonFunctionalMethod(maybeString2);
        functionalMethod(maybeString1);
        functionalMethod(maybeString2);
    }

    private static void nonFunctionalMethod(Optional<String> optString) {
        if (optString.isPresent()) {
            String s = optString.get();
            if (s.length() > 5) {
                System.out.println(s.toUpperCase());
            }
        }
    }

    private static void functionalMethod(Optional<String> optString) {
        optString
            .filter(s -> s.length() > 5)
            .map(String::toUpperCase)
            .ifPresent(System.out::println)
            ;
    }
}
