namespace DesignPatterns.Common.Models;

public sealed record OrderWebhook(Guid Id, WebhookType Type, Guid ResourceId, IReadOnlyDictionary<string, string> Changes);