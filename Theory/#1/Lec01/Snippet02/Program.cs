//MyClass m1 = new() { MyProperty = 42 };
//MyClass m2 = new() { MyProperty = 42 };

//if(!m1.Equals(m2))
//{
//    Console.WriteLine("Not equals");
//}

//class MyClass
//{
//    public int MyProperty { get; set; }
//}



////#10 Enum

//namespace Lec1
//{
//    class enumsSnippet
//    {
//        public enum Colors
//        {
//            Red,
//            Green,
//            Blue
//        }
//        static void Main()
//        {
//            Colors color = Colors.Red;
//            Console.WriteLine(color);
//            Console.WriteLine((int)color);//за перечислением по-умолчанию Int

//            color = (Colors)2;//возможно и обратное преобразование
//            Console.WriteLine(color);

//            Enum.TryParse<Colors>("Green", out color);//TryParse
//            Console.WriteLine(color);

//            foreach (var c in Enum.GetNames(typeof(Colors)))//GetNames
//            {
//                Console.WriteLine(c);
//            }

//            //color = Colors.Blue;
//            switch (color)
//            {
//                case Colors.Red:
//                    Console.WriteLine("Red");
//                    break;
//                case Colors.Green:
//                    Console.WriteLine("Green");
//                    break;
//                default:
//                    Console.WriteLine(color);
//                    break;
//            }
//        }
//    }
//}

