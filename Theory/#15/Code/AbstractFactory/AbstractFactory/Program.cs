using System.Data.Common;


var saver = new LogSaver(SqlClientFactory.Instance);
var loader = new LogFileLoader(args[0]);
saver.Save(loader.Load());


public class LogSaver
{
    private readonly DbProviderFactory _factory;
    public LogSaver(DbProviderFactory factory)
    {
        _factory = factory;
    }
    public void Save(IEnumerable<LogEntry> logEntries)
    {
        using (var connection = _factory.CreateConnection())
        {
            SetConnectionString(connection);
            using (var command = _factory.CreateCommand())
            {
                SetCommandArguments(logEntries);
                command.ExecuteNonQuery();
            }
        }
    }
    private void SetConnectionString(DbConnection connection)
    { }
    private void SetCommandArguments(IEnumerable<LogEntry> logEntry)
    { }
}