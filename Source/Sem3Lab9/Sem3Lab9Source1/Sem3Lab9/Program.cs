using System.Net.Http.Headers;
class Program
{
    // дебагнуть, почему-то ломается где response 404 (или no_data) если работает, то для некоторых тикеров нет даты
    static object filelock = new object();
    static string output = "results.txt";
    static string acces_token = "MVdZTXp6NXBGWlZvLVBSLUhmSjlmV0o4djUtQ1BvbjQ4bnA2VzYtQWxYOD0";
    static async Task Main()
    {
        var tickers = System.IO.File.ReadAllLines("ticker.txt");
        var tasks = new List<Task>();
        foreach (var ticker in tickers)
        {
            var startDate = new DateTimeOffset(DateTime.Now.AddMonths(-8)).ToUnixTimeSeconds();
            var endDate = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            var url = $"https://api.marketdata.app/v1/stocks/candles/D/{ticker}/?from={startDate}&to={endDate}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", acces_token);
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                var lines = content.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                double totalPrice = 0;
                int days = 30;
                var fields = lines[0].Split(',');
                var high = double.Parse(fields[2]);
                var low = double.Parse(fields[3]);
                totalPrice += (high + low) / 2;

                var AveragePrice = totalPrice / days;

                lock (filelock)
                {
                    File.AppendAllText(output, $"{ticker} : {AveragePrice:F2}{Environment.NewLine}");
                }
                Console.WriteLine($"средняя цена акции {ticker} за год : {AveragePrice:F2}");
            }
            await Task.WhenAll(tasks);
        }
    }
}