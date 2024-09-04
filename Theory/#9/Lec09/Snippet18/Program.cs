ParentAndChild();
Console.ReadLine();


static void ParentAndChild()
{
    Task parent = new(ParentTask);
    parent.Start();
    Task.Delay(1000).Wait();
    Console.WriteLine("Parent status:"+parent.Status);
    Task.Delay(4000).Wait();
    Console.WriteLine("Parent status:" + parent.Status);
}

static void ParentTask()
{
    Console.WriteLine($"task id {Task.CurrentId}");
    Task child = new(ChildTask);
    child.Start();
    Task.Delay(1000).Wait();
    Console.WriteLine("parent started child");
}

static void ChildTask()
{
    Console.WriteLine("child");
    Task.Delay(5000).Wait();
    Console.WriteLine("child finished");
}