DeleteDuplicateFiles("dirWithCopies",true);

void DeleteDuplicateFiles(string directory, bool checkOnly = true)
{
    IEnumerable<string> fileNames = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
    string previousFileName = string.Empty;
    foreach (string fileName in fileNames)
    {
        string previousName = Path.GetFileNameWithoutExtension(previousFileName);
        int ix = previousFileName.LastIndexOf(" - Copy");
        if (!string.IsNullOrEmpty(previousFileName) && previousName.EndsWith(" - Copy") && fileName.StartsWith(previousFileName[..ix]))
        {
            FileInfo copiedFile = new(previousFileName);
            FileInfo originalFile = new(fileName);
            if (copiedFile.Length == originalFile.Length)
            {
                Console.WriteLine($"delete {copiedFile.FullName}");
                if (!checkOnly)
                {
                    copiedFile.Delete();
                }
            }
        }
        previousFileName = fileName;
    }
}