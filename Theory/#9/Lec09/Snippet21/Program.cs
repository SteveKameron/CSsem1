
StateObject _s1 = new();
StateObject _s2 = new();

Task.Run(() => Deadlock1());
Task.Run(() => Deadlock2());

Task.Delay(10000).Wait();

void Deadlock1()
{
    int i = 0;
    while (true)
    {
        Console.WriteLine("1 - waiting for s1");
        lock (_s1)
        {
            Console.WriteLine("1 - s1 locked, waiting for s2");
            lock (_s2)
            {
                Console.WriteLine("1 - s1 and s2 locked, now go on...");
                _s1.ChangeState(i);
                _s2.ChangeState(i++);
                Console.WriteLine($"1 still running, i: {i}");
            }
        }
    }
}

void Deadlock2()
{
    int i = 0;
    while (true)
    {
        Console.WriteLine("2 - waiting for s2");

        lock (_s2)
        {
            Console.WriteLine("2 - s2 locked, waiting for s1");
            lock (_s1)
            {
                Console.WriteLine("2 - s1 and s2 locked, now go on...");
                _s1.ChangeState(i);
                _s2.ChangeState(i++);
                Console.WriteLine($"2 still running, i: {i}");
            }
        }
    }
}

class StateObject
{
    private int _state = 5;
    // private object _sync = new object();

    public bool ChangeState(int loop)
    {
        //lock (sync)
        {
            if (_state == 5)
            {
                _state++;
                if (_state != 6)
                {
                    Console.WriteLine($"Race condition occured after {loop} loops");
                    //Trace.Fail($"race condition at {loop}");
                    return false;
                }
            }
            _state = 5;//set it back to 5
            return true;
        }
    }
}