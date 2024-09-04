using System.Diagnostics.Contracts;

public class LogFileReader : IDisposable
{
    private readonly string _logFileName;
    private readonly Action<string> _logEntrySubscriber;
    private readonly static TimeSpan CheckFileInterval =
    TimeSpan.FromSeconds(5);
    private readonly Timer _timer;
    public LogFileReader(string logFileName,
    Action<string> logEntrySubscriber)
    {
        Contract.Requires(File.Exists(logFileName));
        _logEntrySubscriber = logEntrySubscriber;
        _timer = new Timer(new TimerCallback(CheckFile),null, CheckFileInterval, CheckFileInterval);
    }
    public void Dispose()
    {
        _timer.Dispose();
    }
    private void CheckFile(object? obj)
    {
        foreach (var logEntry in ReadNewLogEntries())
        {
            _logEntrySubscriber(logEntry);
        }
    }
    private IEnumerable<string> ReadNewLogEntries()
    {
        // ...
        // Читаем новые записи из файла,
        // которые появились с момента последнего чтения
        return new List<string>() { "Log#1", "Log#2", "Log#3" };
    }
}


public class LogEntryEventArgs : EventArgs
{
    public LogEntryEventArgs(string logEntry)
    {
        LogEntry = logEntry;
    }

    public string LogEntry { get; internal set; }
}
public class LogFileReaderWithEvents : IDisposable
{
    private readonly string _logFileName;
    public LogFileReaderWithEvents(string logFileName)
    {
        //...
    }
    public event EventHandler<LogEntryEventArgs> OnNewLogEntry;

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    private void CheckFile()
    {
        foreach (var logEntry in ReadNewLogEntries())
        {
            RaiseNewLogEntry(logEntry);
        }
    }

    private void RaiseNewLogEntry(object logEntry)
    {
        throw new NotImplementedException();
    }

    private IEnumerable<object> ReadNewLogEntries()
    {
        throw new NotImplementedException();
    }


}