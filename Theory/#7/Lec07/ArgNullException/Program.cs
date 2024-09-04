void HireCSOriginal(Person manager, Person employee)
{
    if (manager == null)
    {
        throw new ArgumentNullException(nameof(manager));
    }
    if (employee == null)
    {
        throw new ArgumentNullException(nameof(employee));
    }
    
}

void HireCS10(Person manager, Person employee)
{
    ArgumentNullException.ThrowIfNull(manager);
    ArgumentNullException.ThrowIfNull(employee);
}

//void HireCS11(Person manager!!, Person employee!!)
//{
    
//}

class Person
{

}