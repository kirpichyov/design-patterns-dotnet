using DesignPatterns.Common.Contracts;

namespace DesignPatterns.TemplateMethod.ConcreteHandlers;

public class SmsHandler : SendNotificationCommandHandlerBase
{
    public SmsHandler(
        IUserRepository userRepository,
        IEventsRepository eventsRepository)
        : base(userRepository, eventsRepository)
    {
    }

    protected override void SendNotification(UserNotificationServices userServices)
    {
        if (userServices.Phone is not null)
        {
            Console.WriteLine($"Send notification via SMS to '{userServices.Phone}'");
            return;
        }
        
        Console.WriteLine("Ignore command since user has no phone saved.");
    }
}