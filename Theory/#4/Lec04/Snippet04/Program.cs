Person[] persons = {
new("Damon", "Hill"),
 new("Niki", "Lauda"),
 new("Ayrton", "Senna"),
 new("Graham", "Hill")
};
Array.Sort(persons);
foreach (var p in persons)
{
    Console.WriteLine(p);
}


record Person(string FirstName, string LastName) : IComparable<Person>
{
    public int CompareTo(Person? other)
    {
        if (other == null) return 1;
        int result = string.Compare(FirstName, other.FirstName);
        if(result==0) result = string.Compare(LastName, other.LastName);
        return result;
    }
}

