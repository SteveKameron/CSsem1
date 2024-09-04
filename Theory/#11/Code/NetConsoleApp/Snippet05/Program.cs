using Snippet05;

CancellationTokenSource cancellationTokenSource = new();

Console.CancelKeyPress += (sender, e) =>
{
    Console.WriteLine("cancellation initiated by the user");
    cancellationTokenSource.Cancel();
};

var client = new EchoClient();
await client.SendAndReceiveAsync(cancellationTokenSource.Token);

Console.ReadLine();