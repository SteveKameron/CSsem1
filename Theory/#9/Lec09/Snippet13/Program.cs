ParallelInvoke();

static void ParallelInvoke()
{
    Parallel.Invoke(Foo, Bar, Foo, Bar, Foo, Bar);
}
 static void Foo() =>
 Console.WriteLine("foo");
 static void Bar() =>
 Console.WriteLine("bar");