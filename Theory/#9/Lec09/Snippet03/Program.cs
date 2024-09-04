CallerWithAsync();
CallerWithAsync();
CallerWithAsync();
Console.ReadLine();



async static void CallerWithAsync()
{
    TraceThreadAndTask($"started {nameof(CallerWithAsync)}");
    string result = await GreetingAsync("Stephanie");
    Console.WriteLine(result);
    TraceThreadAndTask($"ended {nameof(CallerWithAsync)}");
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

