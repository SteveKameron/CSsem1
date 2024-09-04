//named arguments
PrintNum("1", "233", "300", "340");
PrintNum(oneNum: "10", twoNum: "28", "23", "34");


//optional arguments
TestMethod(11);
TestMethod(11, 42);


void PrintNum(string oneNum, string twoNum, string threeNum, string fourNum)
{
    Console.WriteLine($"{oneNum} {twoNum} {threeNum} {fourNum}");
}

void TestMethod(int notOptionalNumber, int optionalNumber = 42)
{
    Console.WriteLine(optionalNumber + notOptionalNumber);
}

