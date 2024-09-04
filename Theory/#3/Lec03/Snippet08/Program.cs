var pc = new PersonCollection(new Person( "ff", "dd", new DateTime(1980, 01, 01)));
Console.WriteLine(pc[0]);

public record Person(string FirstName, string LastName, DateTime Birthday)
{
    public override string ToString() => $"{FirstName} {LastName}";
}
public class PersonCollection
{
    public IEnumerable<Person> this[DateTime birthDay]
    {
        get => _people.Where(p=> p.Birthday == birthDay);
    }
    public Person this[int index]
    {
        get=> _people[index];
        set => _people[index] = value;
    }
    private Person[] _people;
    public PersonCollection(params Person[] people) =>
    _people = people.ToArray();
}