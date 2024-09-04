CreateFile("HelloWorld.txt");
FileInformation("Snippet4.txt");
//ChangeFileProperties("Snippet4.txt");

void CreateFile(string file)
{
    try
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), file);
        File.WriteAllText(path, "Hello, World!");
        Console.WriteLine($"created file {path}");
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Invalid characters in the filename?");
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void FileInformation(string file)
{
    FileInfo fileInfo = new(file);
    if (!fileInfo.Exists)
    {
        Console.WriteLine("File not found");
        return;
    }
    Console.WriteLine($"Name: {fileInfo.Name}");
    Console.WriteLine($"Directory: {fileInfo.DirectoryName}");
    Console.WriteLine($"Read only: {fileInfo.IsReadOnly}");
    Console.WriteLine($"Extension: {fileInfo.Extension}");
    Console.WriteLine($"Length: {fileInfo.Length}");
    Console.WriteLine($"Creation time: {fileInfo.CreationTime:F}");
    Console.WriteLine($"Access time: {fileInfo.LastAccessTime:F}");
    Console.WriteLine($"File attributes: {fileInfo.Attributes}");
}

void ChangeFileProperties(string file)
{
    FileInfo fileInfo = new(file);
    if (!fileInfo.Exists)
    {
        Console.WriteLine($"File {file} does not exist");
        return;
    }

    Console.WriteLine($"creation time: {fileInfo.CreationTime:F}");
    fileInfo.CreationTime = new DateTime(2035, 12, 24, 15, 0, 0);
    Console.WriteLine($"creation time: {fileInfo.CreationTime:F}");
}