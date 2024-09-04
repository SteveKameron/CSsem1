Func<double,double>[] operations = { MathOperators.MultipleByTwo, MathOperators.Square };

foreach (var op in operations)
{
    Console.WriteLine($"Using operation: [{op.Method.Name}]");
    ProcessAndDisplayNumber(op, 2.0);
    ProcessAndDisplayNumber(op, 7.94);
    ProcessAndDisplayNumber(op, 1.414);
    Console.WriteLine();

}

void ProcessAndDisplayNumber(Func<double,double> action, double value)
{
    double res = action(value);
    Console.WriteLine($"Value is {value}, result of operation is {res}");
}

public static class MathOperators
{
    public static double MultipleByTwo(double val) => val * 2;
    public static double Square(double val) => val * val;
}