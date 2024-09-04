using System.Net.Sockets;
using System.Text;

namespace Snippet07
{
    record QuotesClientOptions
    {
        public string? Hostname { get; init; }
        public int ServerPort { get; init; }
    }

    class QuotesClient
    {
        private readonly string _hostname;
        private readonly int _serverPort;
        public QuotesClient(string hostName, int serverPort)
        {
            _hostname = hostName ?? "localhost";
            _serverPort = serverPort;
        }

        public async Task SendAndReceiveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                Memory<byte> buffer = new byte[4096].AsMemory();
                string? line;
                bool repeat = true;
                while (repeat)
                {
                    Console.WriteLine(@"Press enter to read a quote, ""bye"" to exit");
                    line = Console.ReadLine();
                    if (line?.Equals("bye", StringComparison.CurrentCultureIgnoreCase) == true)
                    {
                        repeat = false;
                    }
                    else
                    {
                        TcpClient client = new();
                        await client.ConnectAsync(_hostname, _serverPort, cancellationToken);
                        using var stream = client.GetStream();
                        int bytesRead = await stream.ReadAsync(buffer, cancellationToken);
                        string quote = Encoding.UTF8.GetString(buffer.Span[..bytesRead]);
                        buffer.Span[..bytesRead].Clear();
                        Console.WriteLine(quote);
                        Console.WriteLine();
                    }
                };
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("so long, and thanks for all the fish");
        }
    }
}
