using System.Text;


//конкатенация
string a = "a";
string b = "b";
string c = a + b;
Console.WriteLine(c);



//StringBuilder
StringBuilder sb = new("the quick");
sb.Append(' ');
sb.Append("brown fox jumped over ");
sb.Append("the lazy dogs 1234567890 times \n");
sb.AppendJoin(";", new string[] { "a", "b", "c", "d" });

string str = sb.ToString();
Console.WriteLine(str);


//String Format
int varA = 10;
var varB = 11;
Console.WriteLine($"Var A is {varA} and var B is {varB}");
Console.WriteLine(String.Format("The sum of var A and var B is {0} {1} {2}", varA + varB, varA, varB));


//FormattableString
double num = 2.516;
Console.WriteLine($"Rounded to two digits num is {num:##.##}");


// Using FormattableString
int x = 3, y = 4;
FormattableString s = $"The result of {x} + {y} is {x + y}";
Console.WriteLine($"format: {s.Format}");
for (int i = 0; i < s.ArgumentCount; i++)
{
    Console.WriteLine($"argument: {i}:{s.GetArgument(i)}");
}
Console.WriteLine();


//Special symb
string s1 = "For \t tabulated \t output \t use \\t";
string s2 = @"Special sybols is \t \r \n";
Console.WriteLine(s1);
Console.WriteLine(s2);

//Raw string literals
string xml = """
            <person age="50">
                <first_name>Mark</first_name>
            </person>
            """;
Console.WriteLine(xml);

//Raw interpolated string literals
var person = new { FirstName = "Alice", Age = 56 };
string json = $$"""
                {
                "first_name": "{{person.FirstName}}",
                "age": {{person.Age}},
                "calculation", "{{{1 + 2}}}"
                }
                """;
Console.WriteLine(json);

