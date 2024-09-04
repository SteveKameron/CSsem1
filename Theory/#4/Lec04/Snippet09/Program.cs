//Hat operator
int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

int first1 = arr[0];
int last1 = arr[arr.Length - 1];
int last2 = arr[^1];
Console.WriteLine($"first: {first1}, last: {last1}, last2: {last2}");
Console.WriteLine(new string('-',20));




//Ranges (..)
ShowRange("full range", arr[..]);//Range fullRange = ..;
ShowRange("first three", arr[0..3]);//Range firstThree = 0..3;
ShowRange("fourth to sixth", arr[3..6]);//Range fourthToSixth = 3..6;
ShowRange("last three", arr[^3..^0]);//Range lastThree = ^3..^0;

void ShowRange(string title, int[] data)
{
    Console.WriteLine(title);
    Console.WriteLine(string.Join(" ", data));
    Console.WriteLine();
}
Console.WriteLine(new string('-', 20));

//Span
var slice = arr[0..3];
slice[0] = -1;
Console.WriteLine($"Original array element:{arr[0]} changed one:{slice[0]}");
Console.WriteLine();
var sliceToSpan = arr.AsSpan()[0..3];
sliceToSpan[0] = 42;
Console.WriteLine($"Original array element:{arr[0]} changed one:{sliceToSpan[0]}");

