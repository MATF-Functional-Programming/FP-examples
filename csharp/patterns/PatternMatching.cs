
// ************************************************************

var output = false switch
{
    true => "true",
    false => "false",
};
// output: false

// ************************************************************

var output = 9 switch
{
    1 => "one",
    2 => "two",
    3 => "three",
    4 => "four",
    5 => "five",
    _ => "other"
};
// output: other

// ************************************************************

var output = 4 switch
{
    < 3  => "less than 3",
    <= 7 => "less than or equal to 7",    
    < 10 => "less than 10",
    _    => "greater than or equal to 10"
};
// output: less than or equal to 7

// ************************************************************

var output = 4 switch
{
    1 or 2 or 3  => "1, 2, or 3",
    > 3 and <= 6 => "between 3 and 6",    
    not 7        => "not 7",
    _            => "7"
};
// output: between 3 and 6

// ************************************************************

var output = (5, false) switch
{
    (< 4, true)  => "lower than 4 and true",
    (< 4, false) => "lower than 4 and false",
    (4, true)    => "4 and true",
    (5, _)       => "five and something",    
    (_, false)   => "something and false",
    _            => "something else",
};
// output: five and something

// ************************************************************

record User(string Name, string Role);

var output = new User("Tim Deschryver", "Developer") switch
{
    { Role: "Admin" }                  => "the user is an admin",
    { Role: "Administrator" }          => "the user is an admin",
    { Name: "Tim", Role: "Developer" } => "the user is Tim and he is a developer",    
    { Name: "Tim" }                    => "the user is Tim and he isn't a developer",
    _                                  => "the user is unknown",
};
// output: the user is Tim and he is a developer

// ************************************************************

record Member(string Name, MemberDetails Details);
record MemberDetails(int MonthsSubscribed, bool Blocked);

var output = new Member("Tim Deschryver", new MemberDetails(8, false)) switch
{
    { Details: { Blocked: true } }         => Array.Empty<string>(),
    { Details: { MonthsSubscribed: < 3 } } => new[] { "comments" },
    { Details: { MonthsSubscribed: < 9 } } => new[] { "comments", "mention" },    
    _                                      => new[] { "comments", "mention", "ping" },
};
// output: comments, mention

// ************************************************************

var greetWithName = true;
var output = "Mrs. Kim" switch
{
    _ when greetWithName == false      => $"Hi",
    "Tim"                              => "Hi Tim!",
    var str when str.StartsWith("Mrs.") 
              || str.StartsWith("Mr.") => $"Greetings {str}",    
    var str                            => $"Hello {str}",
};
// output: Greetings Mrs. Kim

// ************************************************************

var output = new InventoryItemRemoved(3) as object switch
{
    InventoryItemAdded added     => $"Added {added.Amount}",
    InventoryItemRemoved removed => $"Removed {removed.Amount}",    
    InventoryItemDeactivated     => "Deactivated",
    null                         => throw new ArgumentNullException()
    var o                        => throw new InvalidOperationException($"Unknown {o.GetType().Name}")
};
// output: Removed 3

// ************************************************************

var output = ("", "Tim") switch
{
    var (title, name) 
         when title.Equals("Mrs.") 
           || title.Equals("Mr.")   => $"Greetings {title} {name}",
    var (_, name) and (_, "Tim")    => $"Hi {name}!",    
    var (_, name)                   => $"Hello {name}",
};
// output: Hi Tim!

// ************************************************************

var contactInfo = new ContactInfo("Sarah", "Peeters", "0123456789");
var output = contactInfo switch
{
    { TelephoneNumber: not null } and { TelephoneNumber: not "" } info => $"{info.FirstName} {info.LastName} ({info.TelephoneNumber})",    
    _ => $"{contactInfo.FirstName} {contactInfo.LastName}"
};
// output: Sarah Peeters (0123456789)

// ************************************************************

IEnumerable<string> sequence = new[] { "foo" };
var output = sequence switch
{
    string[] { Length: 0 } => "array with no items",
    string[] { Length: 1 } => "array with a single item",    
    string[] { Length: 2 } => "array with 2 items",
    string[]               => $"array with more than 2 items",
    IEnumerable<string> source when !source.Any()      => "empty enumerable",
    IEnumerable<string> source when source.Count() < 3 => "a small enumerable",
    IList<string> list                                 => $"a list with {list.Count} items",
    null                                               => "null",
    _                                                  => "something else"
};
// output: array with a single item

// ************************************************************

// C# 11 preview:
public static int CheckSwitch(int[] values)
    => values switch
    {
        [1, 2, .., 10] => 1,
        [1, 2] => 2,
        [1, _] => 3,
        [1, ..] => 4,
        [..] => 50
    };

WriteLine(CheckSwitch(new[] { 1, 2, 10 }));          // prints 1
WriteLine(CheckSwitch(new[] { 1, 2, 7, 3, 3, 10 })); // prints 1
WriteLine(CheckSwitch(new[] { 1, 2 }));              // prints 2
WriteLine(CheckSwitch(new[] { 1, 3 }));              // prints 3
WriteLine(CheckSwitch(new[] { 1, 3, 5 }));           // prints 4
WriteLine(CheckSwitch(new[] { 2, 5, 6, 7 }));        // prints 50

// ************************************************************

// C# 11 preview:
public static string CaptureSlice(int[] values)
    => values switch
    {
        [1, .. var middle, _] => $"Middle {String.Join(", ", middle)}",
        [.. var all]          => $"All {String.Join(", ", all)}"
    };

// ************************************************************
