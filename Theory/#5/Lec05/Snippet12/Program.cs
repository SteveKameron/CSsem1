using System.Diagnostics;

DocumentManager dm = new();

Task processDocuments = ProcessDocuments.StartAsync(dm);

// Create documents and add them to the DocumentManager
Random random = new();
for (int i = 0; i < 10; i++)
{
    var doc = new Document($"Doc {i}", "content");
    int queueSize = dm.AddDocument(doc);
    Console.WriteLine($"Added document {doc.Title}, queue size: {queueSize}");
    await Task.Delay(random.Next(2000));
}
Console.WriteLine($"finished adding documents");
await processDocuments;
Console.WriteLine("bye!");


public class ProcessDocuments
{
    public static Task StartAsync(DocumentManager dm) =>
        Task.Run(new ProcessDocuments(dm).RunAsync);

    protected ProcessDocuments(DocumentManager dm) =>
        _documentManager = dm ?? throw new ArgumentNullException(nameof(dm));

    private readonly DocumentManager _documentManager;

    protected async Task RunAsync()
    {
        Random random = new();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        bool stop = false;
        do
        {
            if (stopwatch.Elapsed >= TimeSpan.FromSeconds(5))
            {
                //Task stops when there is no new documents in 5sec
                stop = true;
            }
            if (_documentManager.IsDocumentAvailable)
            {
                stopwatch.Restart();
                Document doc = _documentManager.GetDocument();
                Console.WriteLine($"Processing document {doc.Title}");
            }
            await Task.Delay(random.Next(2010));  // wait a random time before processing the next document
        } while (!stop);
        Console.WriteLine("stopped reading documents");
    }
}


public class DocumentManager
{
    private readonly object _syncQueue = new object();

    private readonly Queue<Document> _documentQueue = new();

    public int AddDocument(Document doc)
    {
        lock (_syncQueue)
        {
            _documentQueue.Enqueue(doc);
            return _documentQueue.Count;
        }
    }

    public Document GetDocument()
    {
        lock (_syncQueue)
        {
            return _documentQueue.Dequeue();
        }
    }

    public bool IsDocumentAvailable => _documentQueue.Count > 0;
}
public record Document(string Title, string Content);