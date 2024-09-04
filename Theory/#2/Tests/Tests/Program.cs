Console.WriteLine("Testing Math");

namespace Tests
{
    public class Messages
    {
        public static Func<string> msg1 = () => "Hello there!";
        public static Func<string> msg2 = () => "Good Morning!";
    }

    public class Basic
    {
        public static Func<int, int, int> add = (a, b) => a + b;
        public static Func<int, int, int> mul = (a, b) => a * b;
        public static Func<int, int, int> sub = (a, b) => a - b;
        public static Func<int, int, int> div = (a, b) => a / b;
    }
}