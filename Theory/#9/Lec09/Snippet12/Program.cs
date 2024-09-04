ParallelForEach();


static void ParallelForEach()
{
    string[] data = {"zero", "one", "two", "three", "four", "five",
                "six", "seven", "eight", "nine", "ten", "eleven", "twelve"};
    ParallelLoopResult result =
      Parallel.ForEach<string>(data, s =>
      {
          Console.WriteLine(s);
      });
}