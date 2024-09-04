int? n1 = null;
if (n1.HasValue)
{
    int n2 = n1.Value;
}
int n3 = 42;
int? n4 = n3;

Console.WriteLine(n3);
Console.WriteLine(n4);

//compiler waring
string s = Console.ReadLine();
string? s2 = Console.ReadLine();

int a = 100;
//int b = null;
int? c = 100;


int? number1 = 5;
Nullable<int> number2 = 5;
