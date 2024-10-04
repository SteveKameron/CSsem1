class Program
{
    static void Main()
    {


        Car[] cars = new Car[]
        {
            new Car("Car_1",2023,100),
            new Car("Car_2",2024,320),
            new Car("Car_3",2021,250),
            new Car("Car_4",2020,200),
        };


        //вывод для массива
        static void CarPrinter(Car[] cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }

        Console.WriteLine("Неотсортированный массив");
        CarPrinter(cars);

        Console.WriteLine("Введите по какому полю будет производиться сортировка");
        string Pole = Console.ReadLine();
        switch (Pole)
        {
            case "name":
                Array.Sort(cars, new CarComparer(CarComparer.SortPole.Name));
                Console.WriteLine("Сортировка по Названию");
                CarPrinter(cars);
                break;
            case "year":
                Array.Sort(cars, new CarComparer(CarComparer.SortPole.ProductionYear));
                Console.WriteLine("Сортировка по году выпуска");
                CarPrinter(cars);
                break;
            case "speed":
                Array.Sort(cars, new CarComparer(CarComparer.SortPole.MaxSpeed));
                Console.WriteLine("Сортировка по максимальной скорости");
                CarPrinter(cars);
                break;
            }
        }
    }

class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }
    public Car(string name, int productionYear, int maxSpeed)
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
    }

        public override string ToString()
        {
            return $"{Name} {ProductionYear} {MaxSpeed}";
        }

    }

class CarComparer : IComparer<Car>
{
    // как распознать по какому полю сортировка
    public enum SortPole
    {
        Name, ProductionYear, MaxSpeed
    }

    public SortPole crit;
    public CarComparer(SortPole sortPole)
    {
        crit = sortPole;
    }


    public int Compare(Car x, Car y)
    {
        switch (crit)
        {
            case SortPole.Name:
                return string.Compare(x.Name, y.Name);
            case SortPole.ProductionYear:
                return x.ProductionYear.CompareTo(y.ProductionYear);
            case SortPole.MaxSpeed:
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            default:
                throw new ArgumentException("Неизвестный параметр сортировки");
        }
    }
}