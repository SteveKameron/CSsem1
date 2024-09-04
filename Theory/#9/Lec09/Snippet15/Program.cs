
object s_logLock = new();
LongRunningTask();
Console.ReadLine();

void LongRunningTask()
{
    Task t1 = new(TaskMethod, "long running", TaskCreationOptions.LongRunning);
    t1.Start();
}

void TaskMethod(object? o)
{
    Log(o?.ToString() ?? string.Empty);
}

void Log(string title)
{
    lock (s_logLock)
    {
        Console.WriteLine(title);
        Console.WriteLine($"Task id: {Task.CurrentId?.ToString() ?? "no task"}, " +
        $"thread: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine($"is pooled thread: " +
        $"{Thread.CurrentThread.IsThreadPoolThread}");
        Console.WriteLine($"is background thread: " +
        $"{Thread.CurrentThread.IsBackground}");
        Console.WriteLine();
    }
}