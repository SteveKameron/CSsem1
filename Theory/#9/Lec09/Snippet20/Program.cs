using System.Diagnostics;

RaceConditions();
Console.ReadLine();

void RaceConditions()
{
    StateObject state = new();
    for (int i = 0; i < 2; i++)
    {
        Task.Run(() => RaceCondition(state));
    }
}



void RaceCondition(object o)
{
    if (o is not StateObject state) throw new ArgumentException("o must be a StateObject");
    else
    {
        Console.WriteLine("starting RaceCondition - when does the issue occur?");

        int i = 0;
        while (true)//infinite loop with race conditions awaitening
        { 
            
            //lock (state) // no race condition with this lock
            {
                if (!state.ChangeState(i++))
                {
                    i = 0;//set loop counter back to zero
                }
            }
        }
    }
}

class StateObject
{
    private int _state = 5;
     private object _sync = new object();

    public bool ChangeState(int loop)
    {
        lock (sync)
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