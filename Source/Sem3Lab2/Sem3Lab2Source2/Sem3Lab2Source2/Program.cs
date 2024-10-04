class Program
{
    static void Main(string[] args)
    {
        Vehicle vehicle = new Vehicle(10, 20, 30, 50000, 120, 2015);
        PrintVehicleInfo(vehicle);

        Plane plane = new Plane(100, 200, 10000, 1000000, 800, 2020, 10000, 200);
        PrintVehicleInfo(plane);

        Ship ship = new Ship(50, 100, 10, 5000000, 50, 2018, 1000, 3);
        PrintVehicleInfo(ship);

        Car car = new Car(5, 10, 2, 30000, 180, 2022);
        PrintVehicleInfo(car);
    }

    static void PrintVehicleInfo(Vehicle Object)
    {
        Console.WriteLine($"Type: {Object.GetType().Name}");
        Console.WriteLine($"X: {Object.x}, Y: {Object.y}, Z: {Object.z}");
        Console.WriteLine($"Price: {Object.Price}, Velocity: {Object.Velocity}, Year: {Object.Year}");

        if (Object is Plane)
        {
            Plane plane = (Plane)Object;
            Console.WriteLine($"Height: {plane.Height}, Passengers: {plane.Passangers}");
        }
        else if (Object is Ship)
        {
            Ship ship = (Ship)Object;
            Console.WriteLine($"Passengers: {ship.Passangers}, Port: {ship.Port}");
        }

        Console.WriteLine();
    }
}

class Vehicle
{
    public int x, y, z;
    public int Price, Velocity, Year;

    public Vehicle(int x, int y, int z, int price, int velocity, int year)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        Price = price;
        Velocity = velocity;
        Year = year;
    }
}

class Plane : Vehicle
{
    public int Height, Passangers;

    public Plane(int x, int y, int z, int price, int velocity, int year, int height, int pass) : base(x, y, z, price, velocity, year)
    {
        Height = height;
        Passangers = pass;
    }
}

class Car : Vehicle
{
    public Car(int x, int y, int z, int price, int velocity, int year) : base(x, y, z, price, velocity, year)
    {
    }
}

class Ship : Vehicle
{
    public int Passangers, Port;

    public Ship(int x, int y, int z, int price, int velocity, int year, int pass, int port) : base(x, y, z, price, velocity, year)
    {
        Passangers = pass;
        Port = port;
    }
}

