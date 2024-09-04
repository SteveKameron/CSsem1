using Lec06;
using System.Collections.Concurrent;
using System.Diagnostics;

IList<int> data = SampleData();

LinqQuerySync(data);
LinqQuery(data);
ExtensionMethods(data);
UseAPartitioner(data);
UseCancellation(data);

static void LinqQuerySync(IEnumerable<int> data)
{
    Console.WriteLine(nameof(LinqQuerySync));

    Stopwatch stopwatch = new();
    stopwatch.Start();

    var res = (from x in data
               where Math.Log(x) < 4
               select x).Average();

    stopwatch.Stop();

    Console.WriteLine($"result from {nameof(LinqQuerySync)}: {res} with elapsed milliseconds {stopwatch.ElapsedMilliseconds}");
    Console.WriteLine();
}

static void LinqQuery(IEnumerable<int> data)
{
    Console.WriteLine(nameof(LinqQuery));

    Stopwatch stopwatch = new();
    stopwatch.Start();

    var res = (from x in data.AsParallel()
               where Math.Log(x) < 4
               select x).Average();

    stopwatch.Stop();

    Console.WriteLine($"result from {nameof(LinqQuery)}: {res} with elapsed milliseconds {stopwatch.ElapsedMilliseconds}");
    Console.WriteLine();
}

static void ExtensionMethods(IEnumerable<int> data)
{
    Console.WriteLine(nameof(ExtensionMethods));

    Stopwatch stopwatch = new();
    stopwatch.Start();

    var res = data.AsParallel()
        .Where(x => Math.Log(x) < 4)
        .Select(x => x).Average();

    stopwatch.Stop();

    Console.WriteLine($"result from {nameof(ExtensionMethods)}: {res} with elapsed milliseconds {stopwatch.ElapsedMilliseconds}");

    Console.WriteLine();
}

static void UseAPartitioner(IList<int> data)
{
    Console.WriteLine(nameof(UseAPartitioner));

    Stopwatch stopwatch = new();
    stopwatch.Start();


    var res = (from x in Partitioner.Create(data, loadBalance: true).AsParallel()
               where Math.Log(x) < 4
               select x).Average();

    stopwatch.Stop();

    Console.WriteLine($"result from {nameof(UseAPartitioner)}: {res} with elapsed milliseconds {stopwatch.ElapsedMilliseconds}");

    Console.WriteLine();

}

static void UseCancellation(IEnumerable<int> data)
{
    Console.WriteLine(nameof(UseCancellation));
    var cts = new CancellationTokenSource();

    Task.Run(() =>
    {
        try
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            var res = (from x in data.AsParallel().WithCancellation(cts.Token)
                       where Math.Log(x) < 4
                       select x).Average();

            stopwatch.Stop();

            Console.WriteLine($"result from {nameof(UseAPartitioner)}: {res} with elapsed milliseconds {stopwatch.ElapsedMilliseconds}");
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine(ex.Message);
        }
    });

    Console.WriteLine("Query started");
    Console.Write("Cancel? ");
    string? input = Console.ReadLine();
    if (input?.ToLower().Equals("y") == true)
    {
        cts.Cancel();
    }

    Console.WriteLine();

}

static IList<int> SampleData()
{
    const int arraySize = 50_000_000;
    var r = new Random();
    return Enumerable.Range(0, arraySize).Select(x => r.Next(140)).ToList();
}