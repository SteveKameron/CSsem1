using System.Runtime.CompilerServices;

CallerWithAwaiter();
Console.Read();



static void CallerWithAwaiter()
{
    TraceThreadAndTask($"starting {nameof(CallerWithAwaiter)}");
    TaskAwaiter<string> awaiter = GreetingAsync("Matthias").GetAwaiter();
    awaiter.OnCompleted(OnCompleteAwaiter);

    void OnCompleteAwaiter()
    {
        Console.WriteLine(awaiter.GetResult());
        TraceThreadAndTask($"ended {nameof(CallerWithAwaiter)}");
    }
}


static Task<string> GreetingAsync(string name) =>
       Task.Run(() =>
       {
           TraceThreadAndTask($"running {nameof(GreetingAsync)}");
           return Greeting(name);
       });

static string Greeting(string name)
{
    TraceThreadAndTask($"running {nameof(Greeting)}");
    Task.Delay(3000).Wait();
    return $"Hello, {name}";
}

static void TraceThreadAndTask(string info)
{
    string taskInfo = Task.CurrentId == null ? "no task" : "task " + Task.CurrentId;

    Console.WriteLine($"{info} in thread {Thread.CurrentThread.ManagedThreadId} and {taskInfo}");
}