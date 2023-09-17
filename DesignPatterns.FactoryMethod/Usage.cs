using DesignPatterns.Common.Contracts;
using DesignPatterns.Common.Models;

namespace DesignPatterns.FactoryMethod;

public class Usage
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;

    public Usage(IOrderRepository orderRepository, ICacheService cacheService, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _cacheService = cacheService;
        _mapper = mapper;
    }

    public async Task Main()
    {
        // In real world dependency is resolved via IoC/DI Container.
        var factory = new WebhookHandlerFactory(_orderRepository, _cacheService, _mapper);

        var webhook = new OrderWebhook(
            Guid.NewGuid(),
            WebhookType.OrderCreated,
            Guid.NewGuid(),
            new Dictionary<string, string>()
            {
                { "status", "created" },
                { "customerId", "13401052" },
                { "createdAtUtc", "2023-09-02T13:03:56Z" },
            });

        var webhookHandler = factory.CreateHandler(webhook.Type);
        await webhookHandler.HandleAsync(webhook);
    }
}