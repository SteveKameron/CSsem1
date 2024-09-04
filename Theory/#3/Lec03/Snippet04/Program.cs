//////nullable types
//int? a = null;
//int b;
//b = a ?? 10; // b has the value 10

//Console.WriteLine(b);


//a = 3;
//b = a ?? 10; // b has the value 3

//Console.WriteLine(b);



//MyClassExtentions m2 = new();
//var m = m2.Val;
//var M = m2.Val;

//Console.WriteLine(m.X);
//Console.WriteLine(M.X);

////reference types
//class MyClassExtentions
//{
//    private MyClass _val;
//    public MyClass Val
//    {
//        get => _val ?? (_val = new MyClass());
//        //get => _val ??= new MyClass();
//    }
//}
//class MyClass
//{
//    public MyClass()
//    {
//        X = new Random().Next(0, 10);
//    }
//    public int X { get; set; }
//}



////#2 null-conditional operator
//double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
//{
//    return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
//}

//var sum1 = SumNumbers(null, 0);
//Console.WriteLine(sum1);  // output: NaN

//var numberSets = new List<double[]>
//{
//    new[] { 1.0, 2.0, 3.0 },
//    null,
//    null
//};

//var sum2 = SumNumbers(numberSets, 0);
//Console.WriteLine(sum2);  // output: 6

//var sum3 = SumNumbers(numberSets, 2);
//Console.WriteLine(sum3);



////#3 null-conditional operator
int GetSumOfFirstTwoOrDefault(int[] numbers)
{
    if ((numbers?.Length ?? 0) < 2)//true if numbers is null or .Length <2
    {
        return 0;
    }
    return numbers[0] + numbers[1];
}

Console.WriteLine(GetSumOfFirstTwoOrDefault(null));  // output: 0
Console.WriteLine(GetSumOfFirstTwoOrDefault(new int[0]));  // output: 0
Console.WriteLine(GetSumOfFirstTwoOrDefault(new[] { 3, 4, 5 }));  // output: 7



