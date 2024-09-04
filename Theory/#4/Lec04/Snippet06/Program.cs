
HelloWorld();

void HelloWorld()
{
    HelloCollection helloCollection = new();
    foreach (string s in helloCollection)
    {
        Console.WriteLine(s);
    }
}

class HelloCollection
{
    public IEnumerator<string> GetEnumerator()
    {
        yield return "Hello";
        yield return "World";
    }
}

