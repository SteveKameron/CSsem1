
using static System.Console;
using System.Text.RegularExpressions;  // Regex

////Snip1
//do
//{
//	Write("Enter your age: ");
//	string input = ReadLine()!; // null-forgiving
//	Regex ageChecker = new(@"\d$");
//	if (ageChecker.IsMatch(input))
//	{
//		WriteLine($"Thank you!  {Environment.NewLine}");
//	}
//	else
//	{
//		WriteLine($"This is not a valid age: {input} {Environment.NewLine}");
//	} 
//} while (true);

////Snip2
//string films = """
//"Monsters, Inc.","I, Tonya","Lock, Stock and Two Smoking Barrels"
//""";

//WriteLine($"Films to split: {films}");

//string[] filmsArr = films.Split(',');

//WriteLine($"{Environment.NewLine} Splitting with string.Split method:");

//foreach (string film in filmsArr)
//{
//	WriteLine(film);
//}

//WriteLine(Environment.NewLine);

//Regex csv = new(
// "(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");

//MatchCollection filmsSmart = csv.Matches(films);

//WriteLine("Splitting with regular expression:");

//foreach (Match film in filmsSmart)
//{
//	WriteLine(film.Groups[2].Value);
//}
