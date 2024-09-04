///#3 data types
namespace myprog
{
    public class Program
    {
        static void Main()
        {

            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(bool), sizeof(bool), bool.TrueString, bool.FalseString);

            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(byte), sizeof(byte), byte.MinValue, byte.MaxValue);
            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(sbyte), sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);

            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(char), sizeof(char), char.MinValue, char.MaxValue);

            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(short), sizeof(short), short.MinValue, short.MaxValue);
            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(ushort), sizeof(ushort), ushort.MinValue, ushort.MaxValue);

            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(int), sizeof(int), int.MinValue, int.MaxValue);
            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(uint), sizeof(uint), uint.MinValue, uint.MaxValue);

            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(long), sizeof(long), long.MinValue, long.MaxValue);
            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(ulong), sizeof(ulong), ulong.MinValue, ulong.MaxValue);

            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(decimal), sizeof(decimal), decimal.MinValue, decimal.MaxValue);
            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(float), sizeof(float), float.MinValue, float.MaxValue);
            Console.WriteLine("size of {0} \tis \t{1} bytes, \tmin:{2} max:{3} ", typeof(double), sizeof(double), double.MinValue, double.MaxValue);

        }
    }
}