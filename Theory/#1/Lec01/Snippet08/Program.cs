
public class Person
{
    private int _age;
    private string _name;
    public string _address;
    public string Phone { get; set; }//auto impl.

    // public int Age { get { return _age; } set { _age = value;} }
    public int Age { get => _age; set => _age = value; }//one statement
    public string Name 
    { 
        get 
        { 
            return _name; 
        } 
        set 
        { 
            _name = value; 
        } 
    }

    //public int Address { get; private set; }
    public string Address
    {
        get => _address;
        private set => _address = value;
    }

}