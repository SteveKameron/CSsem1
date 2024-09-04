using Lec06;

//Default where<TSource> extension method:
//public static IEnumerable<TSource> Where<TSource>(
// this IEnumerable<TSource> source,
// Func<TSource, bool> predicate)
//{
//    foreach (TSource item in source)
//    {
//        if (predicate(item))
//            yield return item;
//    }
//}

List<Racer> champions = new(Formula1.GetChampions());
var brazilChampions =
champions.Where(r => r.Country == "Brazil")
.OrderByDescending(r => r.Wins)
.Select(r => r);
foreach (Racer r in brazilChampions)
{
    Console.WriteLine($"{r:A}");
}
