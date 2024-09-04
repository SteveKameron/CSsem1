

object s_logLock = new();
TasksUsingThreadPool();
Console.ReadLine();


void TasksUsingThreadPool()
{
    TaskFactory tf = new();
    Task t1 = tf.StartNew(TaskMethod, "using a task factory");
    Task t2 = Task.Factory.StartNew(TaskMethod, "factory via a task");
    Task t3 = new(TaskMethod, "using a task constructor and Start");
    t3.Start();
    Task t4 = Task.Run(() => TaskMethod("using the Run method"));
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