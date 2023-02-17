import java.util.*;
import java.util.function.*;
import java.util.stream.*;

public class WordCount {

    public static void main(String[] args) {
        var words = new ArrayList<String>();
        
        try (var sc = new Scanner(System.in)) {
            sc.useDelimiter("\\b");
            while (sc.hasNext()) {
                words.add(sc.next());
            }
        }

        words
            .stream()
            .map(str -> str.trim().toLowerCase())
            .filter(str -> !str.isEmpty())
            .filter(WordCount::isWord)
            .collect(
                Collectors.toMap(
                    Function.identity(), 
                    w -> 1,
                    (v1, v2) -> v1 + v2
                )
            )
            .entrySet()
            .stream()
            .sorted(Map.Entry.comparingByValue(Comparator.reverseOrder()))
            .map(WordCount::formatEntry)
            .limit(10)
            .collect(Collectors.toList())
            .forEach(System.out::println)
            ;
    }

    private static boolean isWord(String s) {
        return s.chars().allMatch(Character::isLetter);
    }

    private static String formatEntry(Map.Entry<String, Integer> e) {
        return e.getKey() + ": " + e.getValue();
    }
}
