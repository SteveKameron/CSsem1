//////#1
////var g = new Giraffe();
////var a = new Animal();
////FeedMammals(g);
////FeedMammals(a);



////// Output:
////// Eating.
////// Animal is not a Mammal

////SuperNova sn = new SuperNova();
////TestForMammals(g);
////TestForMammals(sn);

////static void FeedMammals(Animal a)
////{
////    if (a is Mammal m)//cast is successfull
////    {
////        m.Eat();
////    }
////    else
////    {
////        // variable 'm' is not in scope here, and can't be used.
////        Console.WriteLine($"{a.GetType().Name} is not a Mammal");
////    }
////}

////static void TestForMammals(object o)
////{
////    // You also can use the as operator and test for null
////    // before referencing the variable.
////    var m = o as Mammal;
////    if (m != null)
////    {
////        Console.WriteLine(m.ToString());
////    }
////    else
////    {
////        Console.WriteLine($"{o.GetType().Name} is not a Mammal");
////    }
////}
////// Output:
////// I am an animal.
////// SuperNova is not a Mammal

////class Animal
////{
////    public void Eat() { Console.WriteLine("Eating."); }
////    public override string ToString()
////    {

////        return "I am an animal.";
////    }
////}
////class Mammal : Animal { }
////class Giraffe : Mammal { }

////class SuperNova { }



////#2
//int i = 5;
//PatternMatchingNullable(i);

//int? j = null;
//PatternMatchingNullable(j);

//double d = 9.78654;
//PatternMatchingNullable(d);

//Console.ReadLine();

//PatternMatchingSwitch(i);
//PatternMatchingSwitch(j);
//PatternMatchingSwitch(d);

//static void PatternMatchingNullable(ValueType? val)
//{
//    if (val is int j) // Nullable types are not allowed in patterns
//    {
//        Console.WriteLine(j);
//    }
//    else if (val is null) // If val is a nullable type with no value, this expression is true
//    {
//        Console.WriteLine("val is a nullable type with the null value");
//    }
//    else
//    {
//        Console.WriteLine("Could not convert " + val.ToString());
//    }
//}

//static void PatternMatchingSwitch(ValueType? val)
//{
//    switch (val)
//    {
//        case int number:
//            Console.WriteLine(number);
//            break;
//        case long number:
//            Console.WriteLine(number);
//            break;
//        case decimal number:
//            Console.WriteLine(number);
//            break;
//        case float number:
//            Console.WriteLine(number);
//            break;
//        case double number:
//            Console.WriteLine(number);
//            break;
//        case null:
//            Console.WriteLine("val is a nullable type with the null value");
//            break;
//        default:
//            Console.WriteLine("Could not convert " + val.ToString());
//            break;
//    }
//}