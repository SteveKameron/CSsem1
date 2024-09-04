
static void One()
{
    Console.WriteLine("One");
    throw new Exception("Error in One");
}

static void Two()
{
    Console.WriteLine("Two");
}

Action d1 = One;
d1 += Two;

//try
//{
//    d1.Invoke();
//}
//catch { }

//Delegate[] delegates = d1.GetInvocationList();
//foreach (Action d in delegates)
//{
//    try
//    {
//        d();
//    }
//    catch (Exception)
//    {
//        Console.WriteLine("Exception caught");
//    }
//}