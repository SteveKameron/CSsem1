
using System.Net;
using System.Net.Sockets;

namespace Snippet05
{
    class EchoClient
    {
        private readonly string _hostname;
        private readonly int _serverPort;
        public EchoClient(int port = 8200)
        {
            _hostname = "localhost";
            _serverPort = port;
        }

        public async Task SendAndReceiveAsync(CancellationToken cancellationToken)
        {
            try
            {
                //ip resolve
                var addresses = await Dns.GetHostAddressesAsync(_hostname);
                IPAddress ipAddress = addresses.Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
                if (ipAddress is null)
                {
                    Console.WriteLine("no IPv4 address");
                    return;
                }
                //registering socket
                Socket clientSocket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //connecting
                await clientSocket.ConnectAsync(ipAddress, _serverPort, cancellationToken);

                Console.WriteLine("client connected to echo service");
                using NetworkStream stream = new(clientSocket, ownsSocket: true);

                Console.WriteLine("enter text that is streamed to the server and returned");

                // send the input from Console to the network stream
                Stream consoleInput = Console.OpenStandardInput();
                Task sender = consoleInput.CopyToAsync(stream, cancellationToken);


                // receive the output from the network stream and put it into Console
                Stream consoleOutput = Console.OpenStandardOutput();
                Task receiver = stream.CopyToAsync(consoleOutput, cancellationToken);

                await Task.WhenAll(sender, receiver);
                Console.WriteLine("sender and receiver completed");
            }
            catch (SocketException ex) when (ex.ErrorCode == 10061)
            {
                Console.WriteLine("Is the server running?");
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
