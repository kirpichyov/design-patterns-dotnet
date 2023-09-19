namespace DesignPatterns.Observer;

public sealed record OrderUpdatedEvent(Guid OrderId, string Status, DateTime EstimatedTimeUtc);