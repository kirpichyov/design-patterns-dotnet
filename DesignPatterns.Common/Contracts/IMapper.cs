using DesignPatterns.Common.Models;

namespace DesignPatterns.Common.Contracts;

public interface IMapper
{
    Order ToOrder(OrderWebhook orderWebhook);
}