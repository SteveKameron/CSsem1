Action<double> operations = MathOperations.MultiplyByTwo;
operations += MathOperations.Square;


ProcessAndDisplayNumber(operations, 2.0);
ProcessAndDisplayNumber(operations, 7.94);
ProcessAndDisplayNumber(operations, 1.414);

void ProcessAndDisplayNumber(Action<double> action, double value)
{
    Console.WriteLine($"ProcessAndDisplayNumber called with value = {value}");
    action(value);
    Console.WriteLine();
}

public static class MathOperations
{
    public static void MultiplyByTwo(double value) =>
        Console.WriteLine($"Multiplying by 2: {value} gives {value * 2}");

    public static void Square(double value) =>
        Console.WriteLine($"Squaring: {value} gives {value * value}");
}