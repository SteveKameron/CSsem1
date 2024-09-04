Console.WriteLine(Path.Combine(@"D:\Projects", "ReadMe.txt"));

Console.ReadKey();

ShowSpecialFolders();

void ShowSpecialFolders()
{
    foreach (var specialFolder in Enum.GetNames(typeof(Environment.SpecialFolder)))
    {
        Environment.SpecialFolder folder = Enum.Parse<Environment.SpecialFolder>(specialFolder);

        string path = Environment.GetFolderPath(folder);
        Console.WriteLine($"{specialFolder}: {path}");
    }
}