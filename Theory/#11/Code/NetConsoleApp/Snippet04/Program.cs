using Snippet04;

CancellationTokenSource cancellationTokenSource = new();
Console.CancelKeyPress += (sender, e) =>
{
    Console.WriteLine("cancellation initiated by the user");
    cancellationTokenSource.Cancel();
};
EchoServer service = new();
await service.StartListenerAsync(cancellationTokenSource.Token);
Console.ReadLine();