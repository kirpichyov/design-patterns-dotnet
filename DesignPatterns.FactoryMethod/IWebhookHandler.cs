using DesignPatterns.Common.Models;

namespace DesignPatterns.FactoryMethod;

public interface IWebhookHandler
{
    Task HandleAsync(OrderWebhook orderWebhook);
}