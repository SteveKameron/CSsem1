﻿
using System.Collections;

class Program
{
    static void Main()
    {
        Car[] cars = new Car[]
        {
            new Car("Car_1",1993, 200),
            new Car("Car_2",2000, 250),
            new Car("Car_3",1899, 100),
            new Car("Car_4",2019, 300),
        };

        CarCatalog catalog = new CarCatalog(cars);

        Console.WriteLine("Прямой проход");
        foreach (Car car in catalog)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("Обратный обход");
        foreach (Car car in catalog.GetEnumeratorR())
        {
            Console.WriteLine(car);
        }
        Console.WriteLine("Проход с фильтром по году выпуска");
        Console.WriteLine("Введите год выпуска: ");
        int year = int.Parse(Console.ReadLine());
        foreach (Car car in catalog.ByProductionYear(year))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("Проход с фильтром по максимальной скорости");
        Console.WriteLine("Введите максимальную скорость");
        int speed = int.Parse(Console.ReadLine());
        foreach (Car car in catalog.ByMaxSpeed(speed))
        {
            Console.WriteLine(car);
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

class CarCatalog : IEnumerable<Car>
{
    public Car[] cars;

    public CarCatalog(Car[] cars)
    {
        this.cars = cars;
    }


    // прямой обход
    public IEnumerator<Car> GetEnumerator()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            yield return cars[i]; 
        }
    }
    // обратный обход
    public IEnumerable<Car> GetEnumeratorR()
    {
        for (int i = cars.Length - 1; i >= 0; i--)
        {
            yield return cars[i];
        }
    }
    // обход с фильтром года
    public IEnumerable<Car> ByProductionYear(int year)
    {
        foreach (Car car in cars)
        {
            if (car.ProductionYear >= year)
            {
                yield return car;
            }
        }
    }

    // обход с филтром скорости
    public IEnumerable<Car> ByMaxSpeed(int maxSpeed)
    {
        foreach (Car car in cars)
        {
            if (car.MaxSpeed >= maxSpeed)
            {
                yield return car;
            }
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return cars.GetEnumerator();
    }
}