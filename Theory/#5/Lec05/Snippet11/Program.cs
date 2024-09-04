List<Racer> racerList = new();
List<int> nums = new List<int> { 1, 2, 3, 4, 5 };
List<string> names = new() { "Max", "John", "Julia" };


#region List resizing efficiency
//List<int> intList = new();
//var watch = new System.Diagnostics.Stopwatch();
//watch.Start();

//for (int i = 0; i < 20000000; i++)
//{
//    intList.Add(new Random().Next(1000000));
//}

//watch.Stop();

//Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms. Elements added: {intList.Count}");

//watch = new System.Diagnostics.Stopwatch();
//List<int> intList2 = new(20000000);

//watch.Start();

//for (int i = 0; i < 20000000; i++)
//{
//    intList2.Add(new Random().Next(1000000));
//}

//watch.Stop();

//Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms. Elements added: {intList2.Count}");

#endregion

#region Add
List<int> intList = new();
intList.Add(1);
intList.Add(2);
List<string> stringList = new();
stringList.Add("one");
stringList.Add("two");

Racer graham = new(7, "Graham", "Hill", "UK", 14);
Racer emerson = new(13, "Emerson", "Fittipaldi", "Brazil", 14);
Racer mario = new(16, "Mario", "Andretti", "USA", 12);

List<Racer> racers = new(20) { graham, emerson, mario };
racers.Add(new Racer(24, "Michael", "Schumacher", "Germany", 91));
racers.Add(new Racer(27, "Mika", "Hakkinen", "Finland", 20));

racers.AddRange(new Racer[] {
 new(14, "Niki", "Lauda", "Austria", 25),
 new(21, "Alain", "Prost", "France", 51)});


List<Racer> drivers = new(
 new Racer[] {
 new (12, "Jochen", "Rindt", "Austria", 6),
 new (22, "Ayrton", "Senna", "Brazil", 41) });


#endregion

//#region Insert
racers.Insert(3, new Racer(6, "Phil", "Hill", "USA", 3));
//#endregion

//#region Access
Racer r1 = racers[3];
for (int i = 0; i < racers.Count; i++)
{
    //   Console.WriteLine(racers[i]);
}

foreach (var r in racers)
{
    // Console.WriteLine(r);
}
//#endregion

//#region Remove
if (!racers.Remove(graham))
{
    //Console.WriteLine("object not found in collection");
}
int index = 3;
int count = 5;
racers.RemoveRange(index, count);
//#endregion

//#region Search
int index1 = racers.IndexOf(mario);

//public int FindIndex(Predicate<T> match);
//public delegate bool Predicate<T>(T obj);

int index2 = racers.FindIndex(x => x.Country == "Finland");
Racer racer = racers.Find(r => r.FirstName == "Niki");
List<Racer> bigWinners = racers.FindAll(r => r.Wins > 20);
foreach (Racer r in bigWinners)
{
    //Console.WriteLine($"{r:A}");
}
//#endregion

//#region Sorting
racers.Sort();
racers.Sort(new RacerComparer(RacerComparer.CompareType.Country));

racers.Sort(new Comparison<Racer>((r1, r2) => 
{ 
    //реализовать логику сравнения объектов можно в лямбда выражении
    return 0; 
}));

//#endregion
public record Racer(int ID, string FirstName, string LastName, string Country, int Wins) : IComparable<Racer>, IFormattable
{
    public Racer(int id, string firstName, string lastName, string country) : this(id, firstName, lastName, country, Wins: 0)
    { }

    public int CompareTo(Racer? other)
    {
        int compare = LastName?.CompareTo(other?.LastName) ?? -1;
        if (compare == 0)
        {
            return FirstName?.CompareTo(other?.FirstName) ?? -1;
        }
        return compare;
    }

    public override string ToString() => $"{FirstName} {LastName}";

    public string? ToString(string format) => ToString(format, null);

    public string ToString(string? format, IFormatProvider? formatProvider) =>
     format?.ToUpper() switch
     {
         null => ToString(),
         "N" => ToString(),
         "F" => FirstName,
         "L" => LastName,
         "W" => $"{ToString()}, Wins: {Wins}",
         "C" => Country,
         "A" => $"{ToString()}, Country: {Country}, Wins: {Wins}",
         _ => throw new FormatException(string.Format(formatProvider, "Format {0} is not supported", format))
     };
}

public class RacerComparer : IComparer<Racer>
{
    public enum CompareType
    {
        FirstName,
        LastName,
        Country,
        Wins
    }
    private CompareType _compareType;
    public RacerComparer(CompareType compareType) =>
    _compareType = compareType;
    public int Compare(Racer? x, Racer? y)
    {
        if (x is null && y is null) return 0;
        if (x is null) return -1;
        if (y is null) return 1;
        int CompareCountry(Racer x, Racer y)
        {
            int result = string.Compare(x.Country, y.Country);
            if (result == 0)
            {
                result = string.Compare(x.LastName, y.LastName);
            }
            return result;
        }
        return _compareType switch
        {
            CompareType.FirstName => string.Compare(x.FirstName, y.FirstName),
            CompareType.LastName => string.Compare(x.LastName, y.LastName),
            CompareType.Country => CompareCountry(x, y),
            CompareType.Wins => x.Wins.CompareTo(y.Wins),
            _ => throw new ArgumentException("Invalid Compare Type")
        };
    }
}
