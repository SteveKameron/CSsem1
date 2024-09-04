using System;
using System.Linq;


MyCollection coll = new();
int n = coll[^20];
Console.WriteLine($"Item from the collection: {n}");
ShowRange("Using custom collection", coll[45..^40]);


void ShowRange(string title, int[] data)
{
    Console.WriteLine(title);
    Console.WriteLine(string.Join(" ", data));
    Console.WriteLine();
}

class MyCollection
{
    private int[] _array = Enumerable.Range(0,100).ToArray();
    public int Length => _array.Length;

    public int this[int index]
    {
        get=>_array[index];
        set => _array[index] = value;
    }

    public int[] Slice(int start, int length)
    {
        var slice = new int[length];
        Array.Copy(_array,start,slice,0,length);
        return slice;
    }
}