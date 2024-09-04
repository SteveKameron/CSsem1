using Snippet03.Models;

using (var dc = new StocksContext())
{

    Ticker t = dc.Tickers.First();

    Console.WriteLine(t.Ticker1);

    Price p = new() { Date = DateTime.Now, Price1 = 100, Ticker = t };

    dc.Prices.Add(p);

    dc.SaveChanges();

    Console.WriteLine(dc.Prices.First().Price1);
}

