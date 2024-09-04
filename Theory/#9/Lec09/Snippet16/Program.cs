TaskWithResultDemo();
Console.ReadLine();


static void TaskWithResultDemo()
{
    Task<(int Result, int Remainder)> t1 = new(TaskWithResult, (8, 3));
    t1.Start();
    Console.WriteLine(t1.Result);
    t1.Wait();
    Console.WriteLine($"result from task: {t1.Result.Result} {t1.Result.Remainder}");
}

static (int Result, int Remainder) TaskWithResult(object? division)
{
    if (division is ValueTuple<int, int> div)
    {
        (int x, int y) = div;
        int result = x / y;
        int remainder = x % y;
        Console.WriteLine("task creates a result...");

        return (result, remainder);
    }
    else
    {
        throw new ArgumentException($"{nameof(division)} needs to be a ValueTuiple<int, int>");
    }
}