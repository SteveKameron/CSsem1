﻿using System.IO.Compression;
using System.Text;

CompressFile("file.txt", "file.txt.gzip");
DecompressFile("file.txt.gzip");


CreateZipFile("./arch/", "./Snip09.zip");

void CreateZipFile(string sourceDirectory, string zipFile)
{
    InitSampleFilesForZip(sourceDirectory);  // create sample files if the directory does not exist
    string? destDirectory = Path.GetDirectoryName(zipFile);
    if (destDirectory is not null && !Directory.Exists(destDirectory))
    {
        Directory.CreateDirectory(destDirectory);
    }
    FileStream zipStream = File.Create(zipFile);
    using ZipArchive archive = new(zipStream, ZipArchiveMode.Create);

    IEnumerable<string> files = Directory.EnumerateFiles(sourceDirectory, "*", SearchOption.TopDirectoryOnly);
    foreach (var file in files)
    {
        ZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(file));
        using FileStream inputStream = File.OpenRead(file);
        using Stream outputStream = entry.Open();
        inputStream.CopyTo(outputStream);

    }
}

void InitSampleFilesForZip(string directory)
{
    if (!Directory.Exists(directory))
    {
        Directory.CreateDirectory(directory);

        for (int i = 0; i < 10; i++)
        {
            string destFileName = Path.Combine(directory, $"test{i}.txt");

            File.Copy("file.txt", destFileName);
        }

    } // else nothing to do, using existing files from the directory
}

void DecompressFile(string fileName)
{
    FileStream inputStream = File.OpenRead(fileName);
    using MemoryStream outputStream = new();
    using DeflateStream compressStream = new(inputStream, CompressionMode.Decompress);
    compressStream.CopyTo(outputStream);
    outputStream.Seek(0, SeekOrigin.Begin);
    using StreamReader reader = new(outputStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, bufferSize: 4096, leaveOpen: true);
    string result = reader.ReadToEnd();
    Console.WriteLine(result);
}

void CompressFile(string fileName, string compressedFileName)
{
    using FileStream inputStream = File.OpenRead(fileName) ;
    FileStream outputStream = File.OpenWrite(compressedFileName);
    using DeflateStream compressStream = new(outputStream, CompressionMode.Compress);
    inputStream.CopyTo(compressStream);//stream chain
}