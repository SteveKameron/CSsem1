static void DoOnSecond(Task t)
{
    Console.WriteLine($"task {t.Id} finished");
    Console.WriteLine($"this task id {Task.CurrentId}");
    Console.WriteLine("do some cleanup");
    Task.Delay(3000).Wait();
}

static void DoOnFirst()
{
    Console.WriteLine($"doing some task {Task.CurrentId}");
    Task.Delay(3000).Wait();
}

static void ContinuationTasks()
{
    Task t1 = new(DoOnFirst);
    Task t2 = t1.ContinueWith(DoOnSecond);
    Task t3 = t1.ContinueWith(DoOnSecond);
    Task t4 = t2.ContinueWith(DoOnSecond);
    t1.Start();
}