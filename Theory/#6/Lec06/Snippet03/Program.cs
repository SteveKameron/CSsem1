using Lec06;

List<string> names = new() { "Nino", "Alberto", "Juan", "Mike", "Phil" };

var namesWithJ = from n in names
                    where n.StartsWith("J")
                    orderby n
                    select n;

Console.WriteLine("First iteration");

foreach (string name in namesWithJ)
{
    Console.WriteLine(name);
}

Console.WriteLine();

names.Add("John");
names.Add("Jim");
names.Add("Jack");
names.Add("Denny");

Console.WriteLine("Second iteration");
//запрос скомпилировался, коллекция изменилась - результат запроса изменился
foreach (string name in namesWithJ)
{
    Console.WriteLine(name);
}
