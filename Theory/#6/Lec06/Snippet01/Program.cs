using Lec06;


var query = from r in Formula1.GetChampions()
            where r.Country == "Brazil"
            orderby r.Wins descending
            select r;

foreach (Racer r in query)
{
    Console.WriteLine($"{r:A}");
}


