namespace DesignPatterns.Singleton;

// It can be the external service that requires the only one connection per application.
// E.g. some queue or cache.
public class ExternalServiceConnection
{
    private static ExternalServiceConnection _instance;
    
    private ExternalServiceConnection()
    {
    }

    public static ExternalServiceConnection Instance => _instance ??= new ExternalServiceConnection();

    public Task Publish<T>(T item)
    {
        return Task.CompletedTask;
    }
}