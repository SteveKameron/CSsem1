DontHandle();
Console.ReadLine();

static void DontHandle()
{
    try
    {
        ThrowAfter(200, "first");
        // exception is not caught because this method is finished
        // before the exception is thrown
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static async Task ThrowAfter(int ms, string message)
{
    await Task.Delay(ms);
    throw new Exception(message);
}