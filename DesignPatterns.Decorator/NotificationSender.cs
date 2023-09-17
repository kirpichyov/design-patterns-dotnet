using DesignPatterns.Decorator.Models;

namespace DesignPatterns.Decorator;

public abstract class NotificationSender
{
    public abstract Task Send(Notification notification);
}