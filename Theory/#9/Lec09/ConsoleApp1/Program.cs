//ParallelFor();
ParallelForWithAsync();
Console.ReadLine();


static void ParallelFor()
{
    ParallelLoopResult result =
      Parallel.For(0, 10, i =>
      {
          Log($"S {i}");
          Task.Delay(10).Wait();
          Log($"E {i}");
      });
    Console.WriteLine($"Is completed: {result.IsCompleted}");
}

static void ParallelForWithAsync()
{
    ParallelLoopResult result =
      Parallel.For(0, 10, async i =>
      {
          Log($"S {i}");
          await Task.Delay(10);
          Log($"E {i}");
      });
    Console.WriteLine($"Is completed: {result.IsCompleted}");
}

static void Log(string prefix) =>
        Console.WriteLine($"{prefix} task: {Task.CurrentId}, thread: {Thread.CurrentThread.ManagedThreadId}");