using System.Runtime.CompilerServices;

namespace Snippet06
{
    class Snippet06
    {
        static async Task Main()
        {
            TraceThreadAndTask($"start {nameof(Main)}");
            string result = await GreetingValueTask2Async("Katharina");
            Console.WriteLine(result);
            TraceThreadAndTask($"first result {nameof(Main)}");
            string result2 = await GreetingValueTask2Async("Katharina");
            Console.WriteLine(result2);
            TraceThreadAndTask($"ended {nameof(Main)}");
        }

        static async ValueTask<string> GreetingValueTaskAsync(string name)
        {
            if (names.TryGetValue(name, out string? result))
            {
                return result;
            }
            else
            {
                result = await GreetingAsync(name);
                names.Add(name, result);
                return result;
            }
        }

        static ValueTask<string> GreetingValueTask2Async(string name)
        {
            if (names.TryGetValue(name, out string? result))
            {
                return new ValueTask<string>(result);
            }
            else
            {
                Task<string> t1 = GreetingAsync(name);

                TaskAwaiter<string> awaiter = t1.GetAwaiter();
                awaiter.OnCompleted(OnCompletion);
                return new ValueTask<string>(t1);

                void OnCompletion()
                {
                    names.Add(name, awaiter.GetResult());
                }
            }
        }
        private readonly static Dictionary<string, string> names = new();


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
    }
}