foreach (var n in 5) Console.WriteLine(n);
foreach (var n in -5) Console.WriteLine(n);

static class Int32Extension
{
    public static IEnumerator<int> GetEnumerator(this int number)
    {
        int k = (number > 0) ? number : 0;
        for (int i = number - k; i <= k; i++) yield return i;
    }
}


//Console.WriteLine("simple:");
//MusicTitles titles = new();
//foreach (var title in titles)
//{
//Console.WriteLine(title);
//}
//Console.WriteLine(new String('-', 20));
//Console.WriteLine("reverse:");
//foreach (var title in titles.Reverse())
//{
//Console.WriteLine(title);
//}
//Console.WriteLine(new String('-', 20));
//Console.WriteLine("subset:");
//foreach (var title in titles.Subset(2, 2))
//{
//Console.WriteLine(title);
//}



//public class MusicTitles
//{
//    string[] names = { "Tubular Bells", "Hergest Ridge", "Ommadawn", "Platinum" };
//    public IEnumerator<string> GetEnumerator()
//    {
//        for (int i = 0; i < 4; i++)
//        {
//            yield return names[i];
//        }
//    }
//    public IEnumerable<string> Reverse()
//    {
//        for (int i = 3; i >= 0; i--)
//        {
//            yield return names[i];
//        }
//    }
//    public IEnumerable<string> Subset(int index, int length)
//    {
//        for (int i = index; i < index + length; i++)
//        {
//            yield return names[i];
//        }
//    }
//}
