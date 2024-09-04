

Array intArray1 = Array.CreateInstance(typeof(int), 5);//method requires element's type
for (int i = 0; i < 5; i++)
{
    //intArray1[i] = i;
    intArray1.SetValue(3 * i, i);
}
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(intArray1.GetValue(i));
}



int[] intArray2 = (int[])intArray1;//it's possible to cast to []-array


int[] lengths = { 2, 3 };
int[] lowerBounds = { 1, 10 };

Array racers = Array.CreateInstance(typeof(Person), lengths,lowerBounds);//CreateInstance overload

racers.SetValue(new Person("Alain", "Prost"), 1, 10);
racers.SetValue(new Person("Emerson", "Fittipaldi"), 1, 11);
racers.SetValue(new Person("Ayrton", "Senna"), 1, 12);
racers.SetValue(new Person("Michael", "Schumacher"), 2, 10);
racers.SetValue(new Person("Fernando", "Alonso"), 2, 11);
racers.SetValue(new Person("Jenson", "Button"), 2, 12);

record Person(string FirstName, string LastName);
