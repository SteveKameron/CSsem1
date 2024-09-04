EmployeeId idKyle = new("J18");
Employee kyle = new Employee(idKyle, "Kyle Bush", 138_000.00m);

EmployeeId idMartin = new("J19");
Employee martin = new(idMartin, "Martin Truex Jr", 73_000.00m);

EmployeeId idKevin = new("S4");
Employee kevin = new(idKevin, "Kevin Harvick", 116_000.00m);

EmployeeId idDenny = new EmployeeId("J11");
Employee denny = new Employee(idDenny, "Denny Hamlin", 127_000.00m);

EmployeeId idJoey = new("T22");
Employee joey = new(idJoey, "Joey Logano", 96_000.00m);

EmployeeId idKyleL = new("C42");
Employee kyleL = new(idKyleL, "Kyle Larson", 80_000.00m);


Dictionary<EmployeeId, Employee> employees = new(31)
{
    [idKyle] = kyle,
    [idMartin] = martin,
    [idKevin] = kevin,
    [idDenny] = denny,
    [idJoey] = joey,
};

foreach (var employee in employees.Values)
{
    Console.WriteLine(employee);
}

while (true)
{
    Console.Write("Enter employee id (X to exit)> ");
    string? userInput = Console.ReadLine();
    userInput = userInput?.ToUpper();
    if (userInput == null || userInput == "X") break;

    try
    {
        EmployeeId id = new(userInput);

        if (!employees.TryGetValue(id, out Employee? employee))
        {
            Console.WriteLine($"Employee with id {id} does not exist");
        }
        else
        {
            Console.WriteLine(employee);
        }
    }
    catch (EmployeeIdException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

public record Employee
{
    private readonly string _name;
    private readonly decimal _salary;
    private readonly EmployeeId _id;

    public Employee(EmployeeId id, string name, decimal salary)
    {
        _id = id;
        _name = name;
        _salary = salary;
    }

    public override string ToString() => $"{_id}: {_name,-20} {_salary,12:C}";
}
public class EmployeeIdException : Exception
{
    public EmployeeIdException(string message) : base(message) { }
}

public struct EmployeeId : IEquatable<EmployeeId>
{
    private readonly char _prefix;
    private readonly int _number;

    public EmployeeId(string id)
    {
        ArgumentNullException.ThrowIfNull(id);

        _prefix = (id.ToUpper())[0];
        int last = id.Length > 7 ? 7 : id.Length;
        try
        {
            _number = int.Parse(id[1..last]);
        }
        catch (FormatException)
        {
            throw new EmployeeIdException("Invalid EmployeeId format");
        }
    }

    public override string ToString() => _prefix.ToString() + $"{_number,6:000000}";

    //_number XOR _number  с побитовым сдвигом
    public override int GetHashCode() => (_number ^ _number << 16) * 0x1505_1505;//code fairly evenly distributed

    public bool Equals(EmployeeId other) => _prefix == other._prefix && _number == other._number;

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        return Equals((EmployeeId)obj);
    }

    public static bool operator ==(EmployeeId left, EmployeeId right) => left.Equals(right);

    public static bool operator !=(EmployeeId left, EmployeeId right) => !(left == right);
}