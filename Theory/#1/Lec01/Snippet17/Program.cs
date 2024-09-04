//Deconstructors
class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    

    //public void Deconstruct(out string firstName, out string lastName)
    //{
    //    firstName = FirstName;
    //    lastName = LastName;
    //}
}