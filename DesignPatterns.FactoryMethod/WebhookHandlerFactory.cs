using DesignPatterns.Common.Contracts;
using DesignPatterns.Common.Models;
using DesignPatterns.FactoryMethod.Handlers;

namespace DesignPatterns.FactoryMethod;

public sealed class WebhookHandlerFactory
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;

    public WebhookHandlerFactory(
        IOrderRepository orderRepository,
        ICacheService cacheService,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _cacheService = cacheService;
        _mapper = mapper;
    }

    public IWebhookHandler CreateHandler(WebhookType type)
    {
        return type switch
        {
            WebhookType.OrderCreated => new OrderCreatedHandler(_orderRepository, _cacheService, _mapper),
            WebhookType.OrderUpdated => new OrderUpdatedHandler(_orderRepository, _cacheService, _mapper),
            WebhookType.OrderCancelled => new OrderCancelledHandler(_orderRepository, _cacheService, _mapper),
            WebhookType.OrderCompleted => new OrderCancelledHandler(_orderRepository, _cacheService, _mapper),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
        };
    }
}