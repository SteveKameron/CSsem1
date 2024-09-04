IntroLocalFunctions();
IntroLocalFunctions2();




static void IntroLocalFunctions()
{
    static int Add(int x, int y) => x + y;
    int result = Add(3, 7);
    Console.WriteLine("called the local function with this result: {result}");
}

static void IntroLocalFunctions2()
{
    int c = 3;
    int result = Add(1, 2);
    Console.WriteLine("called the local function with this result: {result}");

    int Add(int a, int b) => a + b + c;
}



struct myStruct
{
    int a=6;
    int b = 42;
    public myStruct()
    {
        a = 1;
        b = 2;
    }
}