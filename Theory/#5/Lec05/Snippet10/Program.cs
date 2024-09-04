

MessageQueueProcessor msgQueProcessor = new MessageQueueProcessor();

MessageLoger logger = new MessageLoger();

msgQueProcessor.MessageReceived += logger.NewMessageReceived;

for (int i = 0; i < 5; i++)
{
    Message m = new Message("Message", new Random(i).Next(100));
    msgQueProcessor.AddNewMessage(m);
    Thread.Sleep(new Random(i).Next(2000));
}

public class MessageQueueProcessor
{
    List<Message> messages;
    public event EventHandler<MessageEventArgs>? MessageReceived;
    public MessageQueueProcessor()
    {
        messages = new List<Message>();
    }
    public void AddNewMessage(Message msg)
    {
        messages.Add(msg);
        MessageReceived?.Invoke(this, new MessageEventArgs(msg));
    }

}
public class MessageLoger
{
    public void NewMessageReceived(object? sender, MessageEventArgs e)
    {
        Console.WriteLine($"{DateTime.Now.ToString("H:mm:ss")}: {e.Message.MessageName} with {e.Message.MessageId} has been received");
    }
}
public class MessageEventArgs : EventArgs
{
    public Message Message { get; }
    public MessageEventArgs(Message message) => Message = message;
}
public record Message(string MessageName, int MessageId);