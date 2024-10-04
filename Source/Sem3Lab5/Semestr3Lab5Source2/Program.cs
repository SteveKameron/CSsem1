
class Program
{
    static void Main()
    {
        MyList<int> List_One = new MyList<int>(1, 2, 3, 4, 5);
        Console.WriteLine("Список List_One: ");
        List_One.PrintList();

        //добавление
        List_One.Add(3);
        Console.WriteLine("Список List_One, с добавленным элементом: ");
        List_One.PrintList();

        MyList<string> List_Two = new MyList<string>("bmw", "lambo", "R-R", "toyota");
        Console.WriteLine("Список List_Two: ");
        List_Two.PrintList();

        //добавление
        List_Two.Add("honda");
        Console.WriteLine("Список List_Two, с добавленным элементом: ");
        List_Two.PrintList();

    }
}
class MyList<T>
{
    private T[] arr;
    

    public MyList(params T[] values)
    {
        arr = values;
    }
    

    public MyList(int sz)
    {
        arr = new T[sz];
    }


    public void Add(T element)
    {
        Array.Resize(ref arr, arr.Length + 1);
        arr[arr.Length - 1] = element;
    }


    public T this[int i]
    {
        get { return arr[i]; }
        set { arr[i] = value; }
    }


    public int Size()
    {
        return arr.Length;
    }

    public  void PrintList()
    {
        for (int i = 0; i < this.Size(); i++)
        {
            Console.WriteLine(this[i] + " ");   
        }
        Console.WriteLine();
    }

}