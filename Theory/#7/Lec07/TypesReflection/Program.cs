var mscorlib = typeof(string).Assembly;
var types = mscorlib.GetTypes()
                    .Where(t => t.Namespace == "System" && t.IsPrimitive);
foreach (var t in types)
{
    Console.WriteLine(t.FullName);
    Console.WriteLine($"\t MinValue:{t.GetField("MinValue")?.GetValue(null)}");
    Console.WriteLine($"\t MaxValue:{t.GetField("MaxValue")?.GetValue(null)}");
}