using DesignPatterns.Common.Contracts;

namespace DesignPatterns.TemplateMethod.ConcreteHandlers;

public class PushHandler : SendNotificationCommandHandlerBase
{
    public PushHandler(
        IUserRepository userRepository,
        IEventsRepository eventsRepository)
        : base(userRepository, eventsRepository)
    {
    }

    protected override void SendNotification(UserNotificationServices userServices)
    {
        if (userServices.ActiveDevices is not null && userServices.ActiveDevices.Length > 0)
        {
            foreach (var device in userServices.ActiveDevices)
            {
                Console.WriteLine($"Send push notification to device with id '{device}'");
            }
            
            return;
        }
        
        Console.WriteLine("Ignore command since user has no active devices.");
    }
}