//#3 Interfaces
using System.Drawing;

Person p1 = new("Jackie", "Stewart");
Person p2 = new("Graham", "Hill");
Person p3 = new("Damon", "Hill");
Person[] people = { p1, p2, p3 };
Array.Sort(people);//Array.Sort from IComparable

foreach (var p in people)
{
    Console.WriteLine(p);
}

public record Person(string FirstName, string LastName) : IComparable<Person>
{
    public int CompareTo(Person? other)//no override keyword
    {
        int compare = LastName.CompareTo(other?.LastName);
        if (compare is 0)
        {
            return FirstName.CompareTo(other?.FirstName);
        }
        return compare;
    }
}
