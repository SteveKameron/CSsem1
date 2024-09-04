Span<int> span1 = IntroSpans();
Console.ReadLine();
Span<int> span2 = CreateSlices(span1);
Console.ReadLine();
ChangeValues(span1, span2);
Console.ReadLine();
ReadonlySpan(span1);
Console.ReadLine();



void ReadonlySpan(Span<int> span1)
{
    Console.WriteLine(nameof(ReadonlySpan));
    int[] arr = span1.ToArray();
    ReadOnlySpan<int> readOnlySpan1 = new(arr);
    DisplaySpan("readOnlySpan1", readOnlySpan1);

    ReadOnlySpan<int> readOnlySpan2 = span1;
    DisplaySpan("readOnlySpan2", readOnlySpan2);
    ReadOnlySpan<int> readOnlySpan3 = arr;
    DisplaySpan("readOnlySpan3", readOnlySpan3);
    Console.WriteLine();
}

void ChangeValues(Span<int> span1, Span<int> span2)
{
    Console.WriteLine(nameof(ChangeValues));
    Span<int> span4 = span1.Slice(start: 4);
    span4.Clear();
    DisplaySpan("content of span1", span1);
    Span<int> span5 = span2.Slice(start: 3, length: 3);
    span5.Fill(42);
    DisplaySpan("content of span2", span2);
    span5.CopyTo(span1);
    DisplaySpan("content of span1", span1);

    if (!span1.TryCopyTo(span4))
    {
        Console.WriteLine("Couldn't copy span1 to span4 because span4 is too small");
        Console.WriteLine($"length of span4: {span4.Length}, length of span1: {span1.Length}");
    }
    Console.WriteLine();
}

Span<int> CreateSlices(Span<int> span1)
{
    Console.WriteLine(nameof(CreateSlices));
    int[] arr2 = { 3, 5, 7, 9, 11, 13, 15 };
    Span<int> span2 = new(arr2);
    Span<int> span3 = new(arr2, start: 3, length: 3);
    Span<int> span4 = span1.Slice(start: 2, length: 4);

    DisplaySpan("content of span3", span3);
    DisplaySpan("content of span4", span4);
    Console.WriteLine();
    return span2;
}

void DisplaySpan(string title, ReadOnlySpan<int> span)
{
    Console.WriteLine(title);
    for (int i = 0; i < span.Length; i++)
    {
        Console.Write($"{span[i]}.");
    }
    Console.WriteLine();
}

Span<int> IntroSpans()
{
    int[] arr1 = { 2, 4, 6, 8, 10, 12 };
    Span<int> span1 = new(arr1);
    span1[1] = 11;
    Console.WriteLine($"arr1[1] is changed via span1[1]: {arr1[1]}");
    Console.WriteLine();
    return span1;
}



//#1
//int[] temperatures = new int[]
//{
//    10, 12, 13, 14, 15, 11, 13, 15, 16, 17,
//    18, 16, 15, 16, 17, 14,  9,  8, 10, 11,
//    12, 14, 15, 15, 16, 15, 13, 12, 12, 11
//};
//int[] firstDecade = new int[10];    // выделяем память для первой декады
//int[] lastDecade = new int[10];     // выделяем память для второй декады
//Array.Copy(temperatures, 0, firstDecade, 0, 10);    // копируем данные в первый массив
//Array.Copy(temperatures, 20, lastDecade, 0, 10);    // копируем данные во второй массив


//#2
//int[] temperatures = new int[]
//{
//    10, 12, 13, 14, 15, 11, 13, 15, 16, 17,
//    18, 16, 15, 16, 17, 14,  9,  8, 10, 11,
//    12, 14, 15, 15, 16, 15, 13, 12, 12, 11
//};
//Span<int> temperaturesSpan = temperatures;

//Span<int> firstDecade = temperaturesSpan.Slice(0, 10);    // нет выделения памяти под данные
//Span<int> lastDecade = temperaturesSpan.Slice(20, 10);    // нет выделения памяти под данные

//#3
//int[] temperatures = new int[]
//{
//    10, 12, 13, 14, 15, 11, 13, 15, 16, 17,
//    18, 16, 15, 16, 17, 14,  9,  8, 10, 11,
//    12, 14, 15, 15, 16, 15, 13, 12, 12, 11
//};
//Span<int> temperaturesSpan = temperatures;

//Span<int> firstDecade = temperaturesSpan.Slice(0, 10);

//temperaturesSpan[0] = 25; // меняем в temperatureSpan
//Console.WriteLine(firstDecade[0]); //25