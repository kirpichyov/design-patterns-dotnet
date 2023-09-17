namespace DesignPatterns.Common.Models;

public sealed class Order
{
    public Guid Id { get; init; }
    public string Status { get; init; }
    public DateTime CreatedAtUtc { get; init; }
}