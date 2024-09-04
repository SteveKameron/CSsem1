using System.Collections.Immutable;

ImmutableArray<string> a1 = ImmutableArray.Create<string>();

ImmutableArray<string> a2 = a1.Add("Williams");

ImmutableArray<string> a3 = a2.Add("Ferrari").Add("Mercedes").Add("Red Bull Racing");


List<Account> accounts = new()
{
    new("Scrooge McDuck", 667377678765m),
    new("Donald Duck", -200m),
    new("Ludwig von Drake", 20000m)
};


ImmutableList<Account> immutableAccounts = accounts.ToImmutableList();

foreach (var account in immutableAccounts)
{
    Console.WriteLine($"{account.Name} {account.Amount}");
}

Console.WriteLine(new String('-',20));

immutableAccounts.ForEach(a => Console.WriteLine($"{a.Name} {a.Amount}"));

public record Account(string Name, decimal Amount);