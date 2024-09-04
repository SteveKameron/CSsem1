WriteAFile();
ReadLineByLine("Snippet5.txt");

void WriteAFile()
{
    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "movies.txt");
    string[] movies =
    {
        "Snow White And The Seven Dwarfs",
        "Gone With The Wind",
        "Casablanca",
        "The Bridge On The River Kwai",
        "Some Like It Hot"
    };

    File.WriteAllLines(fileName, movies);

    string[] moreMovies =
    {
        "Psycho",
        "Easy Rider",
        "Pulp Fiction",
        "Star Wars",
        "The Matrix"
    };
    File.AppendAllLines(fileName, moreMovies);
}

void ReadLineByLine(string file)
{
    IEnumerable<string> lines = File.ReadLines(file);
    int i = 1;
    foreach (var line in lines)
    {
        Console.WriteLine($"{i++}. {line}");
    }
}