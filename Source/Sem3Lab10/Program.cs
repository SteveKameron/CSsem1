using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
class Program
{
    static string access_token = "M0Q3eXdLVlJQckdsVHoyX1hBX0d5SGQ1bWVBWmF0RjU2b282WjlqUDVvaz0";
    static async Task Main()
    {
        var tickers = System.IO.File.ReadAllLines("C:/Users/SteveKameron/source/repos/Sem3Lab10/bin/Debug/net8.0/tickers.txt");
        var tasks = new List<Task>();
        foreach (var ticker in tickers)
        {
            tasks.Add(FetchAndStoreData(ticker));
        }
        await Task.WhenAll(tasks);
    }
    static async Task FetchAndStoreData(string tickerSymbol)
    {
        using (var context = new AppDbContext())
        {
            var startDate = new DateTimeOffset(DateTime.Now.AddDays(-90)).ToUnixTimeSeconds();
            var endDate = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            var url = $"https://api.marketdata.app/v1/stocks/candles/D/{tickerSymbol}/?from={startDate}&to={endDate}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(content);

                if (response.ReasonPhrase == "OK")
                {
                    var ticker = await context.Ticker.FirstOrDefaultAsync(t => t.TickerName == tickerSymbol)
                                 ?? new Tickers { TickerName = tickerSymbol };
                    context.Ticker.Add(ticker);
                    await context.SaveChangesAsync();
                    double[] h = json["h"].ToObject<double[]>();
                    double[] l = json["l"].ToObject<double[]>();
                    var prices_ = new List<Prices>();
                    for (int i = 0; i < h.Length; i++)
                    {
                        double avgPrice = (h[i] + l[i]) / 2;
                        prices_.Add(new Prices { TickerId = ticker.Id, Price = (decimal)avgPrice, Date = DateTime.Now.AddDays(-90 + i) });
                    }

                    await context.Prices.AddRangeAsync(prices_);

                    string state;
                    if (h.Length > 1 && l.Length > 1)
                    {
                        var todayPrice = (decimal)((h.Last() + l.Last()) / 2);
                        var yesterdayPrice = (decimal)((h[h.Length - 1] + l[l.Length - 1]) / 2);
                        state = todayPrice > yesterdayPrice ? "Up" : "Down";
                    }
                    else
                    {
                        state = "Undefined";
                    }

                    var todaysCondition = new TodaysCondition
                    {
                        TickerId = ticker.Id,
                        State = state
                    };

                    context.TodaysCondition.Add(todaysCondition);
                    await context.SaveChangesAsync();

                    Console.WriteLine($"Тикер {tickerSymbol}: сегодня цена {(state == "Up" ? "выросла" : "упала")}.");
                }
                else
                {
                    Console.WriteLine($"Нет данных для тикера - {tickerSymbol}");
                }
            }
        }
    }
}


    public class AppDbContext : DbContext
{
    public DbSet<Tickers> Ticker { get; set; }
    public DbSet<Prices> Prices { get; set; }
    public DbSet<TodaysCondition> TodaysCondition { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=StockMarket;User Id=SA;Password=HelloWorld10;Encrypt=False;TrustServerCertificate=True;");
    }
}

public class Tickers
{
    public int Id { get; set; }
    public string TickerName { get; set; }
}

public class Prices
{
    public int Id { get; set; }
    public int TickerId { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
}

public class TodaysCondition
{
    public int Id { get; set; }
    public int TickerId { get; set; }
    public string State { get; set; }
}
