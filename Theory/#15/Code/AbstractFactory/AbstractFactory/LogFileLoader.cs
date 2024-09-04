internal class LogFileLoader
{
    private string v;

    public LogFileLoader(string v)
    {
        this.v = v;
    }

    internal IEnumerable<LogEntry> Load()
    {
        throw new NotImplementedException();
    }
}