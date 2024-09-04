//StartTwoTasks();
//StartTwoTasksParallel();
ShowAggregatedException();
Console.ReadLine();

static async void StartTwoTasks()
{
    try
    {
        await ThrowAfter(2000, "first");
        await ThrowAfter(1000, "second"); // второй вызов вообще не будет выполнен, т.к. первый выбросил исключение
    }
    catch (Exception ex)
    {
        Console.WriteLine($"handled {ex.Message}");
    }
}

async static void StartTwoTasksParallel()
{
    try
    {
        Task t1 = ThrowAfter(2000, "first");
        Task t2 = ThrowAfter(1000, "second");
        await Task.WhenAll(t1, t2);//оба вызова выполнены, но исключение только от одного
    }
    catch (Exception ex)
    {
        // исключение только от первого вызова
        Console.WriteLine($"handled {ex.Message}");
    }
}

static async void ShowAggregatedException()
{
    Task taskResult = null;
    try
    {
        Task t1 = ThrowAfter(2000, "first");
        Task t2 = ThrowAfter(1000, "second");
        await (taskResult = Task.WhenAll(t1, t2));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"handled {ex.Message}");
        foreach (var ex1 in taskResult.Exception.InnerExceptions)
        {
            Console.WriteLine($"inner exception {ex1.Message}");
        }
    }
}

static async Task ThrowAfter(int ms, string message)
{
    await Task.Delay(ms);
    throw new Exception(message);
}