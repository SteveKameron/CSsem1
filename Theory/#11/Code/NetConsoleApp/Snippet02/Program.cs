using System.Net;

IPAddressSample("8.8.8.8");



void IPAddressSample(string ipAddressString)
{
    if (!IPAddress.TryParse(ipAddressString, out IPAddress? address))
    {
        Console.WriteLine($"cannot parse {ipAddressString}");
        return;
    }

    byte[] bytes = address.GetAddressBytes();
    for (int i = 0; i < bytes.Length; i++)
    {
        Console.WriteLine($"byte {i}: {bytes[i]:X}");
    }

    Console.WriteLine($"family: {address.AddressFamily}, map to ipv6: {address.MapToIPv6()}, map to ipv4: {address.MapToIPv4()}");
    Console.WriteLine($"IPv4 loopback address: {IPAddress.Loopback}");
    Console.WriteLine($"IPv6 loopback address: {IPAddress.IPv6Loopback}");
    Console.WriteLine($"IPv4 broadcast address: {IPAddress.Broadcast}");
    Console.WriteLine($"IPv4 any address: {IPAddress.Any}");
    Console.WriteLine($"IPv6 any address: {IPAddress.IPv6Any}");
}