using Lec06;


//Filters


//SimpleFilter();
//FilterWithIndex();
//FilterWithMethods();
//TypeFilter();

static void SimpleFilter()
{
    Console.WriteLine("filter with a LINQ query based on number wins and the country either Brazil or Austria");

    var racers = from r in Formula1.GetChampions()
                 where r.Wins > 15 && (r.Country == "Brazil" || r.Country == "Austria")
                 select r;

    foreach (var r in racers)
    {
        Console.WriteLine($"{r:A}");
    }
}

 static void FilterWithIndex()
{
    Console.WriteLine("filter using an index - returning every second champion where the lastname stars with A");

    var racers = Formula1.GetChampions()
        .Where((r, index) => r.LastName.StartsWith("A") && index % 2 != 0);//you can pass an index in .Where

    foreach (var r in racers)
    {
        Console.WriteLine($"{r:A}");
    }
}

 static void FilterWithMethods()
{
    Console.WriteLine("filter with the Where method - champions from Brazil and Austria");

    var racers = Formula1.GetChampions()
        .Where(r => r.Wins > 15 && (r.Country == "Brazil" || r.Country == "Austria"));

    foreach (var r in racers)
    {
        Console.WriteLine($"{r:A}");
    }
}

 static void TypeFilter()
{
    Console.WriteLine("query with a type filter - OfType - only getting strings");

    object[] data = { "one", 2, 3, "four", "five", 6 };
    var query = data.OfType<string>();

    foreach (var s in query)
    {
        Console.WriteLine(s);
    }
}