using DesignPatterns.Common.Contracts;

namespace DesignPatterns.TemplateMethod;

public abstract class SendNotificationCommandHandlerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IEventsRepository _eventsRepository;
    
    public SendNotificationCommandHandlerBase(
        IUserRepository userRepository,
        IEventsRepository eventsRepository)
    {
        _userRepository = userRepository;
        _eventsRepository = eventsRepository;
    }

    public void Process(SendNotificationCommand command)
    {
        var userServices = _userRepository.GetUserNotificationServices(command.UserId);
        
        SendNotification(userServices);
        
        _eventsRepository.AddEvent(new { EventType = "command-processed", CommandId = command.Id });
        command.MarkAsProcessed();
    }

    protected abstract void SendNotification(UserNotificationServices userServices);
}