using DesignPatterns.Common.Models;

namespace DesignPatterns.Common.Contracts;

public interface IMapper
{
    Order ToOrder(OrderWebhook orderWebhook);
    OrderModel ToOrderModel(Order order);
    Order ToOrder(OrderResponse orderResponse);
}