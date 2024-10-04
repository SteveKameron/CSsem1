class Program
{
    static void Main()
    {
        Console.WriteLine("Введите курс USD -> RUB");
        double USDtoRUB = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите курс EUR -> RUB");
        double EURtoRUB = Convert.ToDouble(Console.ReadLine());

        CurrencyUSD.USDtoRUBExchange = USDtoRUB;
        CurrencyEUR.EURtoRUBExchange = EURtoRUB;

        CurrencyUSD dollars = new CurrencyUSD(100);
        CurrencyEUR euros = new CurrencyEUR(100);
        CurrencyRUB rubles = new CurrencyRUB(100);

        // преобразование
        CurrencyEUR USD_to_EUR = dollars;
        CurrencyRUB USD_to_RUB = dollars;
        CurrencyUSD EUR_to_USD = euros;
        CurrencyEUR RUB_to_EUR = rubles;

        Console.WriteLine($"100 USD -> EUR: {USD_to_EUR.Value}");
        Console.WriteLine($"100 USD -> RUB: {USD_to_RUB.Value}");
        Console.WriteLine($"100 EUR -> USD: {EUR_to_USD.Value}");
        Console.WriteLine($"100 RUB -> EUR: {RUB_to_EUR.Value}");
    }
}

class Currency
{
    public double Value { get; set; }
}
// ................................................................USD
class CurrencyUSD : Currency
{
    public static double USDtoRUBExchange { get; set; }
    public CurrencyUSD(double value) { Value = value; }
    public CurrencyUSD() { }

    //USD -> EUR
    public static implicit operator CurrencyEUR(CurrencyUSD currencyUSD)
    {
        return new CurrencyEUR
        {
            Value = currencyUSD.Value * USDtoRUBExchange / CurrencyEUR.EURtoRUBExchange
        };
    }

    // USD -> RUB
    public static implicit operator CurrencyRUB(CurrencyUSD currencyUSD)
    {
        return new CurrencyRUB
        {
            Value = currencyUSD.Value * USDtoRUBExchange
        };
    }
}
// ................................................................EUR
class CurrencyEUR : Currency
{
    public static double EURtoRUBExchange { get; set; }
    public CurrencyEUR(double value) { Value = value; }
    public CurrencyEUR() { }

    // EUR -> USD
    public static implicit operator CurrencyUSD(CurrencyEUR currencyEUR)
    {
        return new CurrencyUSD
        {
            Value = currencyEUR.Value * EURtoRUBExchange / CurrencyUSD.USDtoRUBExchange
        };
    }

    // EUR => RUB
    public static implicit operator CurrencyRUB(CurrencyEUR currencyEUR)
    {
        return new CurrencyRUB
        {
            Value = currencyEUR.Value * EURtoRUBExchange
        };
    }
}
// ................................................................RUB
class CurrencyRUB : Currency
{
    public CurrencyRUB(double value) { Value = value; }
    public CurrencyRUB() { }

    // RUB -> EUR
    public static implicit operator CurrencyEUR(CurrencyRUB currencyRUB)
    {
        return new CurrencyEUR 
        { 
            Value = currencyRUB.Value / CurrencyEUR.EURtoRUBExchange
        };
    }

    // RUB -> USD
    public static implicit operator CurrencyUSD(CurrencyRUB currencyRUB)
    {
        return new CurrencyUSD
        {
            Value = currencyRUB.Value / CurrencyUSD.USDtoRUBExchange
        };
    }
}
