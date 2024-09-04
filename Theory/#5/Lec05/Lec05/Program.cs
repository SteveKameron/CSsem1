int x = 42;
GetAString firstStringMethod = new GetAString(x.ToString);
GetString secongStringMethod = Convert.ToString;

Console.WriteLine($"firstStringMethod: {firstStringMethod.Invoke()}");
Console.WriteLine($"secongStringMethod: {secongStringMethod(x)}");




delegate string GetAString();
delegate string GetString(int x);

delegate void IntMethodInvoker(int x);