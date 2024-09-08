// C# 9.0
record User(string Name, string Role);

// Compiles down to:
// region compiled code
class User : IEquatable<User>
{
    [CompilerGenerated]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly string <Name>k__BackingField;

    [CompilerGenerated]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly string <Role>k__BackingField;

    [CompilerGenerated]
    protected virtual Type EqualityContract
    {
        [CompilerGenerated]
        get
        {
            return typeof(User);
        }
    }

    public string Name
    {
        [CompilerGenerated]
        get
        {
            return <Name>k__BackingField;
        }
        [CompilerGenerated]
        init
        {
            <Name>k__BackingField = value;
        }
    }

    public string Role
    {
        [CompilerGenerated]
        get
        {
            return <Role>k__BackingField;
        }
        [CompilerGenerated]
        init
        {
            <Role>k__BackingField = value;
        }
    }

    public User(string Name, string Role)
    {
        <Name>k__BackingField = Name;
        <Role>k__BackingField = Role;
        base..ctor();
    }

    [CompilerGenerated]
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("User");
        stringBuilder.Append(" { ");
        if (PrintMembers(stringBuilder))
        {
            stringBuilder.Append(' ');
        }
        stringBuilder.Append('}');
        return stringBuilder.ToString();
    }

    [CompilerGenerated]
    protected virtual bool PrintMembers(StringBuilder builder)
    {
        RuntimeHelpers.EnsureSufficientExecutionStack();
        builder.Append("Name = ");
        builder.Append((object)Name);
        builder.Append(", Role = ");
        builder.Append((object)Role);
        return true;
    }

    [System.Runtime.CompilerServices.NullableContext(2)]
    [CompilerGenerated]
    public static bool operator !=(User left, User right)
    {
        return !(left == right);
    }

    [System.Runtime.CompilerServices.NullableContext(2)]
    [CompilerGenerated]
    public static bool operator ==(User left, User right)
    {
        return (object)left == right || ((object)left != null && left.Equals(right));
    }

    [CompilerGenerated]
    public override int GetHashCode()
    {
        return (EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(<Name>k__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(<Role>k__BackingField);
    }

    [System.Runtime.CompilerServices.NullableContext(2)]
    [CompilerGenerated]
    public override bool Equals(object obj)
    {
        return Equals(obj as User);
    }

    [System.Runtime.CompilerServices.NullableContext(2)]
    [CompilerGenerated]
    public virtual bool Equals(User other)
    {
        return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(<Name>k__BackingField, other.<Name>k__BackingField) && EqualityComparer<string>.Default.Equals(<Role>k__BackingField, other.<Role>k__BackingField));
    }

    [CompilerGenerated]
    public virtual User <Clone>$()
    {
        return new User(this);
    }

    [CompilerGenerated]
    protected User(User original)
    {
        <Name>k__BackingField = original.<Name>k__BackingField;
        <Role>k__BackingField = original.<Role>k__BackingField;
    }

    [CompilerGenerated]
    public void Deconstruct(out string Name, out string Role)
    {
        Name = this.Name;
        Role = this.Role;
    }
}
// endregion


// More examples
record Member(string Name, MemberDetails Details);
record MemberDetails(int MonthsSubscribed, bool Blocked);

// Records are reference types (like classes)
// For value-type records, use record structs:
public readonly record struct Point(double X, double Y, double Z);

// Records are meant to be immutable, with support for non-destructive copies
var member = new Member(Name: "Foo", new MemberDetails(MonthsSubscribed: 12, Blocked: false));
var shallowCopy = member with { };
var modifiedMember = member with { Name = "Bar" };

// Records can have mutable properties:
public record Person
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
};

// Changing accessibility of a particular parameter:
public record Person(string FirstName, string LastName, string Id)
{
    internal string Id { get; init; } = Id;     // Same name as ^, hides Id
}

// Records can be used to implement "smart-enums" or sum-types
record PaymentType {
    public record CreditCard(CardNumber CardNumber, SecurityCode CVV, Expiration ExpirationDate, NameOnCard Name) : PaymentType();
    public record ACH(AccountNumber AccountNumber, RoutingNumber RoutingNumber) : PaymentType();
    public record Paypal(IntentToken Token) : PaymentType();

    // private constructor can prevent derived cases from being defined elsewhere
    private PaymentType() {} 
}

public void HandlePayment(PaymentType paymentInfo) {
    paymentInfo switch {
        CreditCard cardInfo   => // ...
        ACH        checkInfo  => // ...
        Paypal     paypalInfo => // ...
    };
}
