using Snippet07;

CancellationTokenSource cancellationTokenSource = new();

Console.CancelKeyPress += (sender, e) =>
{
    Console.WriteLine("cancellation initiated by the user");
    cancellationTokenSource.Cancel();
};

var client = new QuotesClient("localhost",8200);
await client.SendAndReceiveAsync(cancellationTokenSource.Token);