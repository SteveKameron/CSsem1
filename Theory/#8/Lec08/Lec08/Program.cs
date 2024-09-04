using (ResourceHolder rh = new())
{
    Console.WriteLine("Resource holder using");
    rh.SomeMethod();
}

public class ResourceHolder : IDisposable
{
    private bool _isDisposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                // Cleanup managed objects by calling their
                // Dispose() methods.
            }
            // Cleanup unmanaged objects
            _isDisposed = true;
        }
    }
    ~ResourceHolder()
    {
        Dispose(false);
    }
    public void SomeMethod()
    {
        // Ensure object not already disposed before execution of any method
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(ResourceHolder));
        }
        // method implementation...
    }
}