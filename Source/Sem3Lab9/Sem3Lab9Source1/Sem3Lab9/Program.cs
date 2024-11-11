using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
class Program
{
    static object filelock = new object();
    static string output = "results.txt";
    static string acces_token = "MVdZTXp6NXBGWlZvLVBSLUhmSjlmV0o4djUtQ1BvbjQ4bnA2VzYtQWxYOD0";
    static async Task Main()
    {
        var tickers = System.IO.File.ReadAllLines("C:/Users/SteveKameron/source/repos/Sem3Lab9Source1/bin/Debug/net6.0/tickers.txt");
        var tasks = new List<Task>();
        foreach (var ticker in tickers)
        {
            tasks.Add(Perform(ticker));
        }
        await Task.WhenAll(tasks);
    }

    static async Task Perform(string ticker)
    {
        var startDate = new DateTimeOffset(DateTime.Now.AddDays(-90)).ToUnixTimeSeconds();
        var endDate = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        var url = $"https://api.marketdata.app/v1/stocks/candles/D/{ticker}/?from={startDate}&to={endDate}";

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", acces_token);
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            if (response.ReasonPhrase == "OK")
            {
                double totalPrice = 0;
                int days = 0;
                double[] h = json["h"].ToObject<double[]>();
                double[] l = json["l"].ToObject<double[]>();
                for (int i = 0; i < h.Length; i++)
                {
                    totalPrice += (h[i] + l[i]) / 2;
                    days++;
                }
                var AveragePrice = totalPrice / days;
                lock (filelock)
                {
                    File.AppendAllText(output, $"{ticker} : {AveragePrice:F2} \n");
                }
                Console.WriteLine($"средняя цена акции {ticker} за год : {AveragePrice:F2}");
            }
            else
            {
                Console.WriteLine($"no data for ticker - {ticker}");
            }
        }
    }
}