using DesignPatterns.Common.Contracts;
using DesignPatterns.Common.Models;

namespace DesignPatterns.Proxy;

public class CachedOrdersRepository : IOrderRepository
{
    private readonly OrderRepository _orderRepository;
    private readonly ICacheService _cacheService;

    public CachedOrdersRepository(OrderRepository orderRepository, ICacheService cacheService)
    {
        _orderRepository = orderRepository;
        _cacheService = cacheService;
    }

    public async Task AddAsync(Order order)
    {
        await _orderRepository.AddAsync(order);
        await _cacheService.AddAsync("orders", order, TimeSpan.FromMinutes(30));
    }

    public async Task AddAsync(Order[] orders)
    {
        await _orderRepository.AddAsync(orders);
        await _cacheService.AddAsync("orders", orders, TimeSpan.FromMinutes(30));
    }

    public async Task UpdateAsync(Order order)
    {
        await _orderRepository.UpdateAsync(order);
        await _cacheService.UpdatePartialAsync("orders", order, x => x.Id == order.Id);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _cacheService.RemovePartialAsync<Order>("orders", x => x.Id == id);
    }

    public async Task<Order[]> GetForUserAsync(Guid userId)
    {
        var cached = await _cacheService.TryGetAsync<Order[]>($"user-{userId}-orders");

        if (cached is not null)
        {
            return cached;
        }

        var stored = await _orderRepository.GetForUserAsync(userId);
        await _cacheService.AddAsync($"user-{userId}-orders", stored, TimeSpan.FromMinutes(30));
        
        return stored;
    }
}