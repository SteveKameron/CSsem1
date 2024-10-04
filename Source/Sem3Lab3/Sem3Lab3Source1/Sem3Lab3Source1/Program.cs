
class Program
{
    static void Main()
    {
        Vector v1 = new Vector(1, 1, 1);
        Vector v2 = new Vector(2, 2, 2);

        Vector sum = v1 + v2;
        double scalar = v1 * v2;
        Vector v1_1 = v1 * 2;

        Console.WriteLine($"Сумма векторов: {sum.x}, {sum.y}, {sum.z}");
        Console.WriteLine($"Скалярное произведение: {scalar}");
        Console.WriteLine($"Умножение вектора на число: {v1_1.x}, {v1_1.y}, {v1_1.z}");
        Console.WriteLine($"v1 > v2: {v1 > v2}");
        Console.WriteLine($"v1 < v2: {v1 < v2}");
        Console.WriteLine($"v1 == v2: {v1 == v2}");
        Console.WriteLine($"v1 !== v2: {v1 != v2}");
    }
}


struct Vector
{
    public double x, y, z;
    // Конструктор с координатами
    public Vector(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    
    // Длина вектора
    public double Length
    {
        get { return Math.Sqrt(x * x + y * y + z * z); }
    }

    // Переопределенная операция сложения двух векторов
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    }

    // Переопределенная операция умножения векторов

    public static double operator * (Vector v1, Vector v2)
    {
        return v1.x*v2.x + v1.y*v2.y + v1.z*v2.z;
    }

    // Переопределение операции умножения вектора на число

    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.x * scalar, v.y * scalar, v.z * scalar);
    }

    // Переопределение логической операции >
    public static bool operator >(Vector v1, Vector v2)
    {
        return v1.Length > v2.Length;
    }

    // Переопределение логической операции >
    public static bool operator <(Vector v1, Vector v2)
    {
        return v1.Length < v2.Length;
    }

    // Переопределение логической операции >= и <=
    public static bool operator <=(Vector v1, Vector v2)
    {
        return v1.Length <= v2.Length;
    }
    public static bool operator >=(Vector v1, Vector v2)
    {
        return v1.Length >= v2.Length;
    }

    // Переопределение логической операции == и !==
    public static bool operator ==(Vector v1, Vector v2)
    {
        return v1.Length == v2.Length;
    }
    
    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }

    
}