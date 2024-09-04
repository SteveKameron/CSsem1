Vector vect1, vect2, vect3;
vect1 = new(3.0, 3.0, 1.0);
vect2 = new(2.0, -4.0, -4.0);
vect3 = vect1 + vect2;
Console.WriteLine($"vect1 = {vect1}");
Console.WriteLine($"vect2 = {vect2}");
Console.WriteLine($"vect3 = {vect3}");

Console.WriteLine($"2 * vect3 = {2 * vect3}");
Console.WriteLine($"vect3 += vect2 gives {vect3 += vect2}");
Console.WriteLine($"vect3 = vect1 * 2 gives {vect3 = vect1 * 2}");
Console.WriteLine($"vect1 * vect3 = {vect1 * vect3}");

readonly struct Vector
{
    public Vector(double x, double y, double z) => (X, Y, Z) = (x, y, z);
    public Vector(Vector v) => (X, Y, Z) = (v.X, v.Y, v.Z);
    public readonly double X;
    public readonly double Y;
    public readonly double Z;
    public override string ToString() => $"( {X}, {Y}, {Z} )";

    public static Vector operator +(Vector left, Vector right) => new Vector(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    public static Vector operator *(Vector left, Vector right) => new Vector(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
    public static Vector operator *(double left, Vector right) => new Vector(left * right.X, left * right.Y, left * right.Z);
    public static Vector operator *(Vector left, double right) => right * left;
}