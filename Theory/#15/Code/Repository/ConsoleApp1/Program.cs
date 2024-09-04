class Program
{
    static void Main(string[] args)
    {
        // Step 1: test for null.
        if (args == null)
        {
            Console.WriteLine("args is null");
        }
        else
        {
            // Step 2: print length, and loop over all arguments.
            Console.Write("args length is ");
            Console.WriteLine(args.Length);
            for (int i = 0; i < args.Length; i++)
            {
                string argument = args[i];
                Console.Write("args index ");
                Console.Write(i); // Write index
                Console.Write(" is [");
                Console.Write(argument); // Write string
                Console.WriteLine("]");
            }
        }
    }
}