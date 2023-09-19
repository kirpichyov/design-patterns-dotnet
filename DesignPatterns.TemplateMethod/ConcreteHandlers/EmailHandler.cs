using DesignPatterns.Common.Contracts;

namespace DesignPatterns.TemplateMethod.ConcreteHandlers;

public class EmailHandler : SendNotificationCommandHandlerBase
{
    public EmailHandler(
        IUserRepository userRepository,
        IEventsRepository eventsRepository)
        : base(userRepository, eventsRepository)
    {
    }

    protected override void SendNotification(UserNotificationServices userServices)
    {
        if (userServices.Email is not null && IsEmailTrusted(userServices.Email))
        {
            Console.WriteLine($"Send notification via Email to '{userServices.Email}'");
            return;
        }
        
        Console.WriteLine("Ignore command since user has no email saved or it's untrusted.");
    }

    private bool IsEmailTrusted(string email)
    {
        return true;
    }
}