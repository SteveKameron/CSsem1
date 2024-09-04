//ctors
public class MyClass
{
    public MyClass() { }
}



public class MyClass2
{
    public MyClass2() // parameterless constructor
    {
        // construction code
    }
    public MyClass2(int number) // constructor overload with an int parameter
    {
        // construction code
    }
}

public class MyNumber
{
    private int _number;
    private MyNumber(int number) => _number = number;
}

public class Singleton
{
    private static Singleton s_instance;
    private int _state;
    private Singleton(int state) => _state = state;
    public static Singleton Instance => s_instance ??= new Singleton(42);
}

public class Book
{
    public Book(string title, string publisher) =>
    (Title, Publisher) = (title, publisher);
    public string Title { get; }
    public string Publisher { get; }
}

class Car
{
    private string _description;
    private uint _nWheels;
    public Car(string description, uint nWheels)
    {
        _description = description;
        _nWheels = nWheels;
    }
    public Car(string description) : this(description, 4)
    {

    }
}