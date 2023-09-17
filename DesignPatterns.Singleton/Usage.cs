namespace DesignPatterns.Singleton;

public class Usage
{
    public void Main()
    {
        var @event1 = new
        {
            id = Guid.NewGuid(),
            data = """"{ "type": "system-launched" }"""",
        };
        
        var @event2 = new
        {
            id = Guid.NewGuid(),
            data = """"{ "type": "system-post-launch" }"""",
        };

        ExternalServiceConnection.Instance.Publish(@event1);
        ExternalServiceConnection.Instance.Publish(@event2);
    }
}