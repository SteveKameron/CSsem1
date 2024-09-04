var instance = LazySingleton.Instance;

Console.WriteLine(LazySingleton.SomeVal);
Console.WriteLine(LazySingleton.SomeVal);
Console.WriteLine(LazySingleton.SomeVal);

Console.WriteLine(new string('_',20));


List<Task> tasks = new List<Task>();
for (int i = 0; i < 10; i++)
{
    Task t = Task.Run(() =>
    {
        Task.Delay(DateTime.Now.Second);
        var singleton = DoubleCheckedLock.Instance;
        Console.WriteLine(DoubleCheckedLock.SomeVal);
    });
    tasks.Add(t);
    Task.WhenAll(tasks).Wait();
}


public sealed class LazySingleton
{
    private static Random _random = new Random(DateTime.Now.Millisecond);

    private static int _someVal;
    private static readonly Lazy<LazySingleton> _instance =
    new Lazy<LazySingleton>(() => 
    {
        _someVal = _random.Next();
        return new LazySingleton();
    });
    LazySingleton() { }
    public static LazySingleton Instance { get { return _instance.Value; } }
    public static int SomeVal { get => _someVal; }
}

public sealed class DoubleCheckedLock
{
    private static Random _random = new Random(DateTime.Now.Millisecond);

    // Поле должно быть volatile!
    private static volatile DoubleCheckedLock _instance;
    private static readonly object _syncRoot = new object();
    private static int _someVal;

    DoubleCheckedLock()
    { }
    public static DoubleCheckedLock Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new DoubleCheckedLock();
                        _someVal = _random.Next();
                    }
                }
            }
            return _instance;
        }
    }
    public static int SomeVal { get => _someVal; }
}