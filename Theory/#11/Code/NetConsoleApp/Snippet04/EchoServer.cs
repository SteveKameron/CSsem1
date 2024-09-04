
using System.Buffers;
using System.IO.Pipelines;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Snippet04
{
    class EchoServer
    {
        private readonly int _port;
        private readonly int _timeout;
        public EchoServer(int port = 8200, int timeOut = 5000)
        {
            _port = port;
            _timeout = timeOut;
        }

        public async Task StartListenerAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                using Socket listener = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.ReceiveTimeout = _timeout;
                listener.SendTimeout = _timeout;

                listener.Bind(new IPEndPoint(IPAddress.Any, _port));
                listener.Listen(backlog: 15);
                Console.WriteLine("EchoListener started on port {0}", _port);
                while (true)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        break;
                    }
                    var socket = await listener.AcceptAsync();
                    if (!socket.Connected)
                    {
                        Console.WriteLine("Client not connected after accept");
                        break;
                    }

                    Console.WriteLine("client connected, local {0}, remote {1}", socket.LocalEndPoint, socket.RemoteEndPoint);

                    Task _ = ProcessClientJobAsync(socket);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private async Task ProcessClientJobAsync(Socket socket, CancellationToken cancellationToken = default)
        {
            try
            {
                using NetworkStream stream = new(socket, ownsSocket: true);

                PipeReader reader = PipeReader.Create(stream);
                PipeWriter writer = PipeWriter.Create(stream);

                bool completed = false;
                do
                {
                    ReadResult result = await reader.ReadAsync(cancellationToken);

                    if (result.Buffer.Length == 0)
                    {
                        completed = true;
                        Console.WriteLine("received empty buffer, client closed");
                    }
                    ReadOnlySequence<byte> buffer = result.Buffer;
                    if (buffer.IsSingleSegment)
                    {
                        string data = Encoding.UTF8.GetString(buffer.FirstSpan);
                        Console.WriteLine("received data {0} from the client {1}", data, socket.RemoteEndPoint);

                        // send the data back
                        await writer.WriteAsync(buffer.First, cancellationToken);
                    }
                    else
                    {
                        int segmentNumber = 0;
                        foreach (var item in buffer)
                        {
                            segmentNumber++;
                            string data = Encoding.UTF8.GetString(item.Span);
                            Console.WriteLine("received data {0} from the client {1} in the {2}. segment", data, socket.RemoteEndPoint, segmentNumber);

                            // send the data back
                            await writer.WriteAsync(item, cancellationToken);
                        }
                    }
                    SequencePosition nextPosition = result.Buffer.GetPosition(result.Buffer.Length);
                    reader.AdvanceTo(nextPosition);

                } while (!completed);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex) when ((ex.InnerException is SocketException socketException) && (socketException.ErrorCode is 10054))
            {
                Console.WriteLine("client {0} closed the connection", socket.RemoteEndPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} with client {1}",ex.Message, socket.RemoteEndPoint);
                throw;
            }
            Console.WriteLine("Closed stream and client socket {0}", socket.RemoteEndPoint);
        }
    }
}
