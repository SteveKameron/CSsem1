Console.WriteLine(nameof(System.Collections.Generic));  // output: Generic
Console.WriteLine(nameof(List<int>));  // output: List
Console.WriteLine(nameof(List<int>.Count));  // output: Count
Console.WriteLine(nameof(List<int>.Add));  // output: Add

var numbers = new List<int> { 1, 2, 3 };
Console.WriteLine(nameof(numbers));  // output: numbers
Console.WriteLine(nameof(numbers.Count));  // output: Count
Console.WriteLine(nameof(numbers.Add));  // output: Add


Person p = new Person();
p.Name = null;
class Person
{
    string? _name;
    public string? Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(Name)} cannot be null");
    }
}