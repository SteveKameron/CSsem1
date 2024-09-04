//#1 Inheritance, overriding, virtual methods, hiding methods (new), base

Shape shape = new();
Rectangle rectangle = new();

//shape.Draw();
//rectangle.Draw();

List<Shape> shapes = new List<Shape>();
shapes.Add(shape);
shapes.Add(rectangle);
foreach (var s in shapes)
{
    s.Draw();
}


//Классы наследники
public class Ellipse : Shape
{
    public void Draw() => DisplayShape();
    protected override void DisplayShape()
    {
        Console.WriteLine($"Ellipse at position {Position} with size {Size}");
    }
}
//Классы наследники
public class Rectangle : Shape
{
    public void Draw() => DisplayShape();

    protected override void DisplayShape()
    {
        Console.WriteLine($"Rectangle at position {Position} with size {Size}");
    }

}
//Базовый класс
public class Shape
{
    public Position Position { get; } = new Position();
    public Size Size { get; } = new Size();

    public void Draw() => DisplayShape();

    protected virtual void DisplayShape()
    {
        Console.WriteLine($"Shape with {Position} and {Size}");
    }
}
public class Position
{
    public int X { get; set; }
    public int Y { get; set; }
}
public class Size
{
    public int Width { get; set; }
    public int Height { get; set; }
}