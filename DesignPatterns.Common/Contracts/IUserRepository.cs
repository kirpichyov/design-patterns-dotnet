namespace DesignPatterns.Common.Contracts;

public interface IUserRepository
{
    UserNotificationServices GetUserNotificationServices(Guid userId);
}

public sealed record UserNotificationServices(string Phone, string Email, Guid[] ActiveDevices);