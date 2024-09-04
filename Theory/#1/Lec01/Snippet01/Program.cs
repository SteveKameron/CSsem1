//#1
int a = 1;
ChangeAValueType(ref a);
Console.WriteLine($"The value of a changed to {a}");
void ChangeAValueType(ref int x)
{
    x = 2;
}



//#2
////передача ссылочного типа по ссылке, попробуем убрать ref
//SomeData data1 = new() { Value = 1 };
//ChangingAReferenceByRef(ref data1);
//Console.WriteLine($"the new value of data1.Value is: {data1.Value}");
//void ChangingAReferenceByRef(ref SomeData data)
//{
//    data.Value = 2;
//    data = new SomeData { Value = 3 };//новый указатель, не меняет объект data
//}
//class SomeData
//{
//    public int Value { get; set; }
//}


//#3
////in - передача по ссылке без возможности изменения
//namespace lec01
//{
//    struct SomeValue
//    {
//        public SomeValue(int value1, int value2, int value3, int value4)
//        {
//            Value1 = value1;
//            Value2 = value2;
//            Value3 = value3;
//            Value4 = value4;
//        }
//        public int Value1 { get; set; }
//        public int Value2 { get; set; }
//        public int Value3 { get; set; }
//        public int Value4 { get; set; }
//    }

//    class lec01
//    { 
//        static void Main()
//        {

//            //MultipleReturn();


//            //SomeValue v = new SomeValue(1,2,3,4);
//            //PassValueByReferenceReadonly(in v);

//        }


//        static void PassValueByReferenceReadonly(in SomeValue data)
//        {
//            //data.Value1 = 4; //нельзя изменить значение только для чтения(read-only)
//        }


//        ///Если метод должен возвращать несколько значений, 
//        ///существуют разные варианты. 
//        ///Один из вариантов — создать собственный тип. 
//        ///Другой вариант — использовать ключевое слово ref с параметрами.
//        ///Используя ключевое слово ref, параметр необходимо инициализировать перед вызовом метода. 
//        ///С помощью ключевого слова ref данные передаются в метод и возвращаются из него. 
//        ///Если метод должен просто возвращать данные, вы можете использовать ключевое слово out.

//        static void MultipleReturn(out int x, out int y)
//        {
//            x = 1;
//            y = 2;
//        }

//        static void MultipleReturn()
//        {
//            int x = 0;
//            int y = 0;

//            MultipleReturn(out x, out y);
//            Console.WriteLine($"{x} {y}");
//        }

//    }
//}


