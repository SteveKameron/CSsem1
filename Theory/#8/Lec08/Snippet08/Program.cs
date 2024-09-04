using System.Text;

ReadFileUsingReader("file.txt");
Console.WriteLine();

string textFile = Path.ChangeExtension(Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()), "txt");
WriteFileUsingWriter(textFile, new string[] { "one", "two" });
Console.WriteLine($"Written temp file {textFile}");



void WriteFileUsingWriter(string fileName, string[] lines)
{
    var outputStream = File.OpenWrite(fileName);
    using StreamWriter writer = new(outputStream, Encoding.UTF8);

    var preamble = Encoding.UTF8.GetPreamble().AsSpan();
    outputStream.Write(preamble);
    foreach (var line in lines)
    {
        writer.WriteLine(line);
    }
}

void ReadFileUsingReader(string fileName)
{
    FileStream stream = new(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
    using StreamReader reader = new(stream);

    while (!reader.EndOfStream)
    {
        string? line = reader.ReadLine();
        Console.WriteLine(line);
    }
}

record Person(string Name);