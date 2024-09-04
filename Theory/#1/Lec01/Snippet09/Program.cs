public class Person
{
    private readonly string _firstName;
    private readonly string _lastName;
    private int _age;

    public Person(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }
    
    public string FirstName => _firstName;
    public string LastName => _lastName;
    public string FullName => $"{FirstName} {LastName}";

    public int Age
    {
        get => _age;
        set => _age = value;
    }
}