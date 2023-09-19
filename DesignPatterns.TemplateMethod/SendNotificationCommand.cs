namespace DesignPatterns.TemplateMethod;

public record SendNotificationCommand(Guid Id, Guid UserId)
{
    public void MarkAsProcessed(){ }
}