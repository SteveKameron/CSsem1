using System.Collections;


class Program
{
    static void Main()
    {
        var myDict = new MyDictionary<string, int>(("apple", 5), ("banana", 3), ("orange", 10), ("arbuz", 8));
        Console.WriteLine($"Размер словаря: {myDict.Size}");
        Console.WriteLine($"Значение для 'banana': {myDict["banana"]}");
        myDict["banana"] = 4;
        Console.WriteLine($"Новое значение для 'banana': {myDict["banana"]}");
        Console.WriteLine("Элементы словаря:");
        myDict.Add("grape", 111);

        foreach (KeyValuePair<string,int> pair in myDict)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}

class MyDictionary<Tkey, Tvalue> : IEnumerable
{
    private Tkey[] keys;
    private Tvalue[] values;

    public MyDictionary(params (Tkey, Tvalue)[] elems)
    {
        keys = new Tkey[elems.Length];
        values = new Tvalue[elems.Length];
        for (int i = 0; i < elems.Length; i++)
        {
            keys[i] = elems[i].Item1;
            values[i] = elems[i].Item2;
        }
    }
    public void Add(Tkey key, Tvalue value)
    {
        if (keys.Contains(key))
        {
            return;
        }
        keys.Append(key);
        values.Append(value);
    }
    public Tvalue this[Tkey key]
    {
        get
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (key.Equals(keys[i]))
                {
                    return values[i];
                }
            }
            return default;
        }
        set
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (key.Equals(keys[i]))
                {
                    values[i] = value;
                    return;
                }
            }
            Add(key, value);
        }
    }
    public int Size => keys.Length;

   public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < Size; i++)
        {
            yield return new KeyValuePair<Tkey, Tvalue>(keys[i], values[i]);
        }
    }


}