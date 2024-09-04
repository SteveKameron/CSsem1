
//value and ref types
namespace myProg
{
    class Program
    {
        // Ссылочный тип(поскольку 'class')
        class SomeRef { public Int32 x; }
        // Значимый тип (поскольку 'struct')
        struct SomeVal { public Int32 x; }

        static void ValueTypeDemo()
        {
            SomeRef r1 = new SomeRef(); // Размещается в куче
            SomeVal v1 = new SomeVal(); // Размещается в стеке
            r1.x = 5; // Разыменовывание указателя 
            v1.x = 5; // Изменение в стеке
            Console.WriteLine(r1.x); // Отображается "5"  
            Console.WriteLine(v1.x); // Также отображается "5"  

            Console.WriteLine(new String('-',20));


            SomeRef r2 = r1; // Копируется только ссылка (указатель)  
            SomeVal v2 = v1; // Помещаем в стек и копируем члены  
            r1.x = 8; // Изменяются r1.x и r2.x 
            v1.x = 9; // Изменяется v1.x, но не v2.x
            Console.WriteLine(r1.x); // Отображается "8"
            Console.WriteLine(r2.x); // Отображается "8" 
            Console.WriteLine(v1.x); // Отображается "9"  
            Console.WriteLine(v2.x); // Отображается "5"   

        }

        static void Main()
        {
            ValueTypeDemo();
        }
    }

}
