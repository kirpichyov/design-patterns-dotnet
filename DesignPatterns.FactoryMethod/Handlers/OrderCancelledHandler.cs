using DesignPatterns.Common.Contracts;
using DesignPatterns.Common.Models;

namespace DesignPatterns.FactoryMethod.Handlers;

public sealed class OrderCancelledHandler : IWebhookHandler
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;

    public OrderCancelledHandler(
        IOrderRepository orderRepository,
        ICacheService cacheService,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _cacheService = cacheService;
        _mapper = mapper;
    }

    public async Task HandleAsync(OrderWebhook orderWebhook)
    {
        var domainOrder = _mapper.ToOrder(orderWebhook);

        await _orderRepository.UpdateAsync(domainOrder);
        await _cacheService.RemoveAsync($"orders-{domainOrder.Id}");
    }
}