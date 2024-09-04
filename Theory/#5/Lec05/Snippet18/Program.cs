using System.Collections.Immutable;

List<Account> accounts = new()
{
    new("Scrooge McDuck", 667377678765m),
    new("Donald Duck", -200m),
    new("Ludwig von Drake", 20000m)
};


ImmutableList<Account> immutableAccounts = accounts.ToImmutableList();

ImmutableList<Account>.Builder builder = immutableAccounts.ToBuilder();

for (int i = builder.Count - 1; i >= 0; i--)
{
    Account a = builder[i];
    if (a.Amount > 0)
    {
        builder.Remove(a);
    }
}

ImmutableList<Account> overdrawnAccounts = builder.ToImmutable();

overdrawnAccounts.ForEach(a => Console.WriteLine($"overdrawn: {a.Name} {a.Amount}"));

public record Account(string Name, decimal Amount);