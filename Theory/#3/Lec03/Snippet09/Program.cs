try
{
    Currency balance = new(50, 35);
    Console.WriteLine(balance);
    Console.WriteLine($"balance is {balance}"); // implicitly invokes ToString
    float balance2 = balance;
    Console.WriteLine($"After converting to float, = {balance2}");
    balance = (Currency)balance2;
    Console.WriteLine($"After converting back to Currency, = {balance}");
    Console.WriteLine("Now attempt to convert out of range value of " +
    "-$50.50 to a Currency:");
    //checked
    //{
        balance = (Currency)(-50.50);
        Console.WriteLine($"Result is {balance}");
    //}
}
catch (Exception e)
{
    Console.WriteLine($"Exception occurred: {e.Message}");
}
public readonly struct Currency
{
    public readonly uint Dollars;
    public readonly ushort Cents;
    public Currency(uint dollars, ushort cents) => (Dollars, Cents) = (dollars, cents);
    public override string ToString() => $"${Dollars}.{Cents,-2:00}";

    public static implicit operator float(Currency value)=>value.Dollars+(value.Cents/100f);

    public static explicit operator Currency(float value)=>new Currency((uint)value,(ushort)((value-(uint)value)*100));
}