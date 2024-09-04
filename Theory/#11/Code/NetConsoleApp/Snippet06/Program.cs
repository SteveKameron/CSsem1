using Snippet06;

CancellationTokenSource cancellationTokenSource = new();

Console.CancelKeyPress += (sender, e) =>
{
    Console.WriteLine("cancellation initiated by the user");
    cancellationTokenSource.Cancel();
};

try
{
    var service = new QuotesServer(8200,"quotes.txt");
    await service.InitializeAsync();
    await service.RunServerAsync(cancellationTokenSource.Token);

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Environment.Exit(-1);
}
Console.ReadLine();