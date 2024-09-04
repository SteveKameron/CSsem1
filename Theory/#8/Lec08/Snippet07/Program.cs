using System.Text;
ReadUsingFileStream("file.txt");
WriteTextFile();



void ReadUsingFileStream(string fileName)
{
    const int BUFFERSIZE = 4096;
    using FileStream stream = new(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
    //using FileStream stream = File.OpenRead(fileName);

    ShowStreamInformation(stream);
    Encoding encoding = GetEncoding(stream);

    var buffer = new byte[BUFFERSIZE].AsSpan();

    bool completed = false;
    do
    {
        int nread = stream.Read(buffer);
        if (nread == 0) completed = true;
        if (nread < buffer.Length)
        {
            buffer[nread..].Clear();
        }

        string s = encoding.GetString(buffer[..nread]);
        Console.WriteLine($"read {nread} bytes");
        Console.WriteLine(s);
    } while (!completed);
}

void ShowStreamInformation(Stream stream)
{
    
    Console.WriteLine($"stream can read: {stream.CanRead} \ncan write: {stream.CanWrite} \ncan seek: {stream.CanSeek} \ncan timeout: {stream.CanTimeout}");
    Console.WriteLine($"length: {stream.Length}, position: {stream.Position}");
    if (stream.CanTimeout)
    {
        Console.WriteLine($"read timeout: {stream.ReadTimeout} write timeout: {stream.WriteTimeout} ");
    }
    Console.WriteLine(new String('_', 20));
}

Encoding GetEncoding(Stream stream)
{
    if (!stream.CanSeek) throw new ArgumentException("require a stream that can seek");

    Encoding encoding = Encoding.ASCII;

    var bom = new byte[5].AsSpan();
    int nRead = stream.Read(bom);
    if (bom[0] is 0xff && bom[1] is 0xfe && bom[2] is 0 && bom[3] is 0)
    {
        Console.WriteLine("UTF-32");
        stream.Seek(4, SeekOrigin.Begin);
        return Encoding.UTF32;
    }
    else if (bom[0] == 0xff && bom[1] == 0xfe)
    {
        Console.WriteLine("UTF-16, little endian");
        stream.Seek(2, SeekOrigin.Begin);
        return Encoding.Unicode;
    }
    else if (bom[0] == 0xfe && bom[1] == 0xff)
    {
        Console.WriteLine("UTF-16, big endian");
        stream.Seek(2, SeekOrigin.Begin);
        return Encoding.BigEndianUnicode;
    }
    else if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
    {
        Console.WriteLine("UTF-8");
        stream.Seek(3, SeekOrigin.Begin);
        return Encoding.UTF8;
    }
    stream.Seek(0, SeekOrigin.Begin);
    return encoding;
}


void WriteTextFile()
{
    string tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
    string tempTextFileName = Path.ChangeExtension(tempFileName, "txt");
    using FileStream stream = File.OpenWrite(tempTextFileName);

    //// write BOM
    //stream.WriteByte(0xef);
    //stream.WriteByte(0xbb);
    //stream.WriteByte(0xbf);

    var preamble = Encoding.UTF8.GetPreamble().AsSpan();
    stream.Write(preamble);

    string hello = "Hello, World!";
    var buffer = Encoding.UTF8.GetBytes(hello).AsSpan();
    stream.Write(buffer);
    Console.WriteLine($"file {stream.Name} written");
}