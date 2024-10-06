class Program
{
    static object filelock = new object();
    static string output = "results.txt";
    static async Task Main()
    {
        var tickers = System.IO.File.ReadAllLines("ticker.txt");
        var tasks = new List<Task>();
        foreach (var ticker in tickers)
        {
            var startDate = new DateTimeOffset(DateTime.Now.AddYears(-1)).ToUnixTimeSeconds();
            var endDate = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            var url = $"https://query1.finance.yahoo.com/v7/finance/download/{ticker}?period1={startDate}&period2={endDate}&interval=1d&events=history&includeAdjustedClose=true";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                var lines = content.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                double totalPrice = 0;
                int days = 0;


                for (int i = 1; i < lines.Length; i++)
                {
                    var fields = lines[i].Split(',');
                    var high = double.Parse(fields[2]);
                    var low = double.Parse(fields[3]);
                    totalPrice += (high + low) / 2;
                    days++;
                }
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