#region First Task

Console.WriteLine($" Size of sbyte: Min = {sbyte.MinValue}, Max = {sbyte.MaxValue}");
Console.WriteLine($" Size of byte: Min = {byte.MinValue}, Max = {byte.MaxValue}");
Console.WriteLine($" Size of short: Min = {short.MinValue}, Max = {short.MaxValue}");
Console.WriteLine($" Size of ushort: Min = {ushort.MinValue}, Max = {ushort.MaxValue}");
Console.WriteLine($" Size of int: Min = {int.MinValue}, Max = {int.MaxValue}");
Console.WriteLine($" Size of uint: Min = {uint.MinValue}, Max = {uint.MaxValue}");
Console.WriteLine($" Size of long: Min = {long.MinValue}, Max = {long.MaxValue}");
Console.WriteLine($" Size of ulong: Min = {ulong.MinValue}, Max = {ulong.MaxValue}");
Console.WriteLine($" Size of float: Min = {float.MinValue}, Max = {float.MaxValue}");
Console.WriteLine($" Size of double: Min = {double.MinValue}, Max = {double.MaxValue}");
Console.WriteLine($" Size of decimal: Min = {decimal.MinValue}, Max = {decimal.MaxValue}");
Console.WriteLine($" Size of bool: Min = {bool.FalseString}, Max = {bool.TrueString}");
Console.WriteLine($" Size of char: Min = {char.MinValue}, Max = {char.MaxValue}");

#endregion

#region Second Task

Console.WriteLine();
Console.WriteLine("Second Task");
double firstSideA = Double.Parse(Console.ReadLine());
double firstSideB = Double.Parse(Console.ReadLine());
Rectangle firstRectangle = new Rectangle(firstSideA, firstSideB);
double firstArea = firstRectangle.Area;
double firstPerimeter = firstRectangle.Perimeter;
Console.WriteLine($"Area: {firstArea}\t Perimeter: {firstPerimeter}");

#endregion

#region Third Task

Console.WriteLine();
Console.WriteLine("Third Task");
Point firstPoint = new(2, 1);
Point secondPoint = new(2, -3);
Point thirdPoint = new(-2, -3);
Point fourthPoint = new(-3, -1);
Point fifthPoint = new(-1, 2);

Figure triangle = new(firstPoint, secondPoint, thirdPoint);
triangle.Print();

Figure quadrangle = new(firstPoint, secondPoint, thirdPoint, fourthPoint);
quadrangle.Print();

Figure pentagon = new(firstPoint, secondPoint, thirdPoint, fourthPoint, fifthPoint);
pentagon.Print();

#endregion


#region Classes
public class Rectangle
{
    double side1 = 0;
    double side2 = 0;
    public Rectangle(double sideA, double sideB)
    {
        side1 = sideA;
        side2 = sideB;
    }
    private double CalculateArea()
    {
        return side1 * side2;
    }
    private double CalculatePerimeter()
    {
        return (side1 + side2) * 2;
    }
    public double Area => CalculateArea();
    public double Perimeter => CalculatePerimeter();

}
public class Point
{
    private int x = 0;
    private int y = 0;
    public Point(int newX, int newY)
    {
        x = newX;
        y = newY;
    }
    public int X => x;
    public int Y => y;
}



public class Figure
{
    //набор из точек фигуры
    public Point[] points;


    //конструктор для 5 точек
    public Figure(Point pointA, Point pointB, Point pointC, Point pointD, Point pointE)
    {
        points = new Point[] { pointA, pointB, pointC, pointD, pointE };
        Name = "Pentagon";
    }


    //конструктор для 4 точек
    public Figure(Point pointA, Point pointB, Point pointC, Point pointD) : this(pointA, pointB, pointC, pointD, null) { Name = "Quadrangle"; }


    //конструктор для 3 точек
    public Figure(Point pointA, Point pointB, Point pointC) : this(pointA, pointB, pointC, null, null) { Name = "Triangle"; }


    //геттер и сеттер для Name
    public string Name { get; set; }

    //Расчет длины
    public double LengthSide(Point pointA, Point pointB)
    {
        if (pointA == null || pointB == null) { return 0; }
        return Math.Pow(Math.Pow(pointA.X - pointB.X, 2) + Math.Pow(pointA.Y - pointB.Y, 2), 0.5);
    }


    //Расчет периметра
    public double PerimeterCalculator()
    {   
        double perimeter = 0;
        if (points[0] == null || points[1] == null) { return 0; }
        perimeter += LengthSide(points[0], points[1]);
        perimeter += LengthSide(points[1], points[2]);
        if (points[3] == null)
        {
            perimeter += LengthSide(points[2], points[0]);
        }
        else
        {
            perimeter += LengthSide(points[2], points[3]);
            if (points[4] == null)
            {
                perimeter += LengthSide(points[3], points[0]);
            }
            else
            {
                perimeter += LengthSide(points[3], points[4]);
                perimeter += LengthSide(points[4], points[0]);
            }
        }
        return perimeter;
    }
    public void Print()
    {
        Console.WriteLine($"Figure Name: {Name}, it's Perimeter: {PerimeterCalculator()}");
    }

}

#endregion