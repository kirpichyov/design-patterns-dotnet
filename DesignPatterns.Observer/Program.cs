using Bogus;

namespace DesignPatterns.Observer;

public static class Program
{
    public static void Main()
    {
        var emailNotifier = new EmailNotifier();
        var ordersTableUI = new OrdersTable();
        var externalServiceCache = new ExternalServiceCache();

        var eventQueue = new OrderUpdatedEventQueue();
        eventQueue.Attach(emailNotifier);
        eventQueue.Attach(ordersTableUI);
        eventQueue.Attach(externalServiceCache);
        
        eventQueue.RaiseOrderUpdatedEvent(Guid.NewGuid(), "delivery in progress", DateTime.UtcNow.AddHours(1));

        eventQueue.Detach(emailNotifier);
        eventQueue.Detach(ordersTableUI);
        eventQueue.Detach(externalServiceCache);
    }
}

// -------------------

public class OrderUpdatedEventQueue
{
    private readonly List<IObserver> _observers = new();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }
    
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void RaiseOrderUpdatedEvent(Guid orderId, string status, DateTime estimatedDeliveryUtc)
    {
        Console.WriteLine("Order update event occured.");
        var @event = new OrderUpdatedEvent(orderId, status, estimatedDeliveryUtc);

        foreach (var observer in _observers)
        {
            observer.HandleOrderUpdate(@event);
        }
    }
}

public interface IObserver
{
    void HandleOrderUpdate(OrderUpdatedEvent @event);
}

public class EmailNotifier : IObserver
{
    public void HandleOrderUpdate(OrderUpdatedEvent @event)
    {
        var faker = new Faker();
        var orderUserEmail = faker.Person.Email;
        
        Console.WriteLine("Sending email with order update to: " + orderUserEmail);
    }
}

public class OrdersTable : IObserver
{
    public void HandleOrderUpdate(OrderUpdatedEvent @event)
    {
        Console.WriteLine("Updating UI table with orders for order " + @event.OrderId);
    }
}

public class ExternalServiceCache : IObserver
{
    public void HandleOrderUpdate(OrderUpdatedEvent @event)
    {
        Console.WriteLine("Updating cache for order " + @event.OrderId);
    }
}