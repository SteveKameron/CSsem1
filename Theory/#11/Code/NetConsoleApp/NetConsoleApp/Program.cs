string amazonUri = "https://www.ozon.ru/product/network-a-video-based-course-elementary-activity-book-598705410/?keywords=network+book";

UriSample(amazonUri);

Console.ReadKey();

BuildUri();

void UriSample(string uri)
{
    Uri page = new(uri);
    Console.WriteLine($"scheme: {page.Scheme}");
    Console.WriteLine($"host: {page.Host}, type: {page.HostNameType}, " +
    $"idn host: {page.IdnHost}");
    Console.WriteLine($"port: {page.Port}");
    Console.WriteLine($"path: {page.AbsolutePath}");
    Console.WriteLine($"query: {page.Query}");
    foreach (var segment in page.Segments)
    {
        Console.WriteLine($"segment: {segment}");
    }
}

void BuildUri()
{
    UriBuilder builder = new();
    builder.Scheme = "https";
    builder.Host = "www.cninnovation.com";
    builder.Port = 80;
    builder.Path = "training/MVC";
    Uri uri = builder.Uri;
    Console.WriteLine(uri);
}