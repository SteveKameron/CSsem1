class Program
{
    static void Main()
    {
        CarsCatalog catalog = new CarsCatalog();
        //1
        catalog.AddCar(new Car { Name = "Car_1", Engine = "Engine_1", MaxSpeed = 1 });
        //2
        catalog.AddCar(new Car { Name = "Car_2", Engine = "Engine_2", MaxSpeed = 2 });
        //3
        catalog.AddCar(new Car { Name = "Car_3", Engine = "Engine_3", MaxSpeed = 3 });


        for (int i = 0; i < catalog.Cars.Count; i++)
        {
            Console.WriteLine(catalog.Cars[i].Name);
        }
        for (int i = 0; i < catalog.Cars.Count; i++)
        {
            Console.WriteLine(catalog[0]);
        }
    }
}

public class Car : IEquatable<Car>
{
    public string Name;
    public string Engine;
    public int MaxSpeed;

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car car)
    {
        if (car == null) return false;
        return (Name == car.Name) && (Engine == car.Engine) && (MaxSpeed == car.MaxSpeed);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        return Equals((Car)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name,Engine,MaxSpeed);
    }
}


class CarsCatalog
{
   public List<Car> Cars = new List<Car>();

    
    public string this[int index]
   {
        get
        {
            Car car = Cars[index];
            return $"{car.Name} - {car.Engine}";
        }
   }

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }

}