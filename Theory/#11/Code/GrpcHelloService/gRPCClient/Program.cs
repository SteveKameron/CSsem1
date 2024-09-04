using System.Threading.Tasks;
using Grpc.Net.Client;
using System;
using GrpcGreeterClient;


using var channel = GrpcChannel.ForAddress("https://localhost:7117");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
                    new HelloRequest { Name = "GreeterClient "+DateTime.Now.Date.ToString() });
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
                    