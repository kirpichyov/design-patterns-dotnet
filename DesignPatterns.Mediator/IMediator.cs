namespace DesignPatterns.Mediator;

public interface IMediator
{
    void Notify(object sender, EventType @event, object args);
}