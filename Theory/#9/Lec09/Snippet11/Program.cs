StopParallelForEarly();


static void StopParallelForEarly()
{
    ParallelLoopResult result =
    Parallel.For(10, 20, (int i, ParallelLoopState pls) =>
    {
        Log($"S {i}");
        if (i > 12)
        {
            pls.Break();
            Log($"break now... {i}");
        }
        Task.Delay(10).Wait();
        Log($"E {i}");
    });
    Console.WriteLine($"Is completed: {result.IsCompleted}");
    Console.WriteLine($"lowest break iteration: {result.LowestBreakIteration}");
}

static void Log(string prefix) =>
        Console.WriteLine($"{prefix} task: {Task.CurrentId}, thread: {Thread.CurrentThread.ManagedThreadId}");