namespace Snippet05
{
    class Snippet05
    {
        static void Main()
        {
            // Call static members
            int x = Math.GetSquareOf(5);
            Console.WriteLine($"Square of 5 is {x}");
            // Instantiate a Math object
            Math math = new();
            // Call instance members
            math.Value = 30;
            Console.WriteLine($"Value field of math variable contains {math.Value}");
            Console.WriteLine($"Square of 30 is {math.GetSquare()}");
        }

        public bool IsSquare(Rectangle rect)
        {
            return (rect.Height == rect.Width);
        }

        //public bool IsSquare(Rectangle rect) => rect.Height == rect.Width;
    }

    public class Rectangle
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class Math
    {
        public int Value { get; set; }
        public int GetSquare() => Value * Value;
        public static int GetSquareOf(int x) => x * x;
    }
}



