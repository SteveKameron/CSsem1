using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Snippet06
{
    record QuotesServerOptions
    {
        public string? QuotesFile { get; init; }
        public int Port { get; init; }
    }
    class QuotesServer
    {
        private readonly int _port;
        private readonly string _quotesPath;
        private string[]? _quotes;
        private Random _random = new();

        public QuotesServer(int port, string quotesFilePath)
        {
            _port = port;
            _quotesPath = quotesFilePath ?? "quotes.txt";
        }

        public async Task InitializeAsync(CancellationToken cancellationToken = default)
            => _quotes = await File.ReadAllLinesAsync(_quotesPath, cancellationToken);

        public async Task RunServerAsync(CancellationToken cancellationToken = default)
        {
            TcpListener listener = new(IPAddress.Any, _port);
            Console.WriteLine("Quotes listener started on port {0}", _port);
            listener.Start();

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                using TcpClient client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected with address and port: {0}", client.Client.RemoteEndPoint);
                var _ = SendQuoteAsync(client, cancellationToken);
            }
        }

        private async Task SendQuoteAsync(TcpClient client, CancellationToken cancellationToken = default)
        {
            try
            {
                client.LingerState = new LingerOption(true, 10);
                client.NoDelay = true;

                using var stream = client.GetStream(); // returns a stream that owns the socket
                var quote = GetRandomQuote();
                var buffer = Encoding.UTF8.GetBytes(quote).AsMemory();
                await stream.WriteAsync(buffer, cancellationToken);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string GetRandomQuote()
        {
            if (_quotes is null) throw new InvalidOperationException($"Invoke InitializeAsync before calling {nameof(GetRandomQuote)}");

            return _quotes[_random.Next(_quotes.Length)];
        }
    }
}





