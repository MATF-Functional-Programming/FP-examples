import java.util.Objects;

// Java 14+
public record Person(int id, String name)

// Equivallent to
public class Person {
    private final int id;
    private final String name;

    public Person(int id, String name) {
        this.id = id;
        this.name = name;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Person person = (Person) o;
        return getId() == person.getId() && getName().equals(person.getName());
    }

    @Override
    public int hashCode() {
        return Objects.hash(getId(), getName());
    }

    @Override
    public String toString() {
        return "Person{" +
                "id=" + id +
                ", name='" + name + '\'' +
                '}';
    }
}

// Template records are also supported:
public record Pair<A, B>(A a, B b) {}

// You can add members to a record class
public record Person(String name, String address) {
    
    public static String UNKNOWN_ADDRESS = "Unknown";

    public static Person unnamed(String address) {
        return new Person(UNKNOWN_ADDRESS, address);
    }
}


