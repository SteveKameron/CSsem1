
Stack<char> alphabet2 = new();
alphabet2.Push('A');
alphabet2.Push('B');
alphabet2.Push('C');
Console.Write("First iteration: ");
foreach (char item in alphabet2)
{
    Console.Write(item);
}
Console.WriteLine();
Console.Write("Second iteration: ");
while (alphabet2.Count > 0)
{
    Console.Write(alphabet2.Pop());
}
Console.WriteLine();