HandleOnError();
Console.ReadLine();

static async void HandleOnError()
{
    try
    {
        await ThrowAfter(2000, "first exception");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"handled {ex.Message}");
    }
}

static async Task ThrowAfter(int ms, string message)
{
    await Task.Delay(ms);
    throw new Exception(message);
}