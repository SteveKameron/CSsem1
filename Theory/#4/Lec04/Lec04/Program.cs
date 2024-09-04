
//int[] myArray = { 10, 20, 30, 42 };

//Console.WriteLine(myArray[0]);

//myArray[0] = 1;

//Console.WriteLine(myArray[0]);

//Console.WriteLine(new String('-',20));

//for(int i=0;i<myArray.Length;i++)
//{
//    Console.WriteLine(myArray[i]);
//}

//Console.WriteLine(new String('-', 20));

//foreach(var val in myArray)
//{
//    Console.WriteLine(val);
//}


////multidimensional arrays
//Console.WriteLine(new String('-', 20));

//int[,] twodim = new int[3, 3];
//twodim[0, 0] = 1;
//twodim[0, 1] = 2;
//twodim[0, 2] = 3;
//twodim[1, 0] = 4;
//twodim[1, 1] = 5;
//twodim[1, 2] = 6;
//twodim[2, 0] = 7;
//twodim[2, 1] = 8;
//twodim[2, 2] = 9;

//int[,] twodim2 = 
//{
//    { 1, 2, 3},
//    { 4, 5, 6},
//    { 7, 8, 9}
//};

//int[,,] threedim = {
// { { 1, 2 }, { 3, 4 } },
// { { 5, 6 }, { 7, 8 } },
// { { 9, 10 }, { 11, 12 } }
//};
//Console.WriteLine(threedim[0, 1, 1]);



////jagged arrays
//Console.WriteLine(new String('-', 20));
//int[][] jagged =
//{
// new[] { 1, 2 },
// new[] { 3, 4, 5, 6, 7, 8 },
// new[] { 9, 10, 11 }
//};

//for (int row = 0; row < jagged.Length; row++)
//{
//    for (int element = 0; element < jagged[row].Length; element++)
//    {
//        Console.WriteLine($"row: {row}, element: {element}, " +
//        $"value: {jagged[row][element]}");
//    }
//}