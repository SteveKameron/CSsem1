//#2 Base constructors

Ellipse ellipse = new(10, 10, 100, 150);
ellipse.Draw();

public class Position
{
    public Position(int x, int y) => (X, Y) = (x, y);
    public int X { get; }
    public int Y { get; }
    public override string ToString() => $"X: {X}, Y: {Y}";
}
public class Size
{
    public Size(int width, int height) => (Width, Height) = (width, height);
    public int Width { get; }
    public int Height { get; }
    public override string ToString() => $"Width: {Width}, Height: {Height}";
}
public abstract class Shape
{
    public Shape(int x, int y, int width, int height)
    {
        Position = new Position(x, y);
        Size = new Size(width, height);
    }
    public Position Position { get; }
    public virtual Size Size { get; }
    public void Draw() => DisplayShape();
    protected virtual void DisplayShape()
    {
        Console.WriteLine($"Shape with {Position} and {Size}");
    }
    public abstract Shape Clone();
}

public class Ellipse : Shape
{
    public Ellipse(int x, int y, int width, int height)
    : base(x, y, width, height) { }
    protected override void DisplayShape()
    {
        Console.WriteLine($"Ellipse at position {Position} with size {Size}");
    }
    public override Ellipse Clone() =>
    new(Position.X, Position.Y, Size.Width, Size.Height);
}
