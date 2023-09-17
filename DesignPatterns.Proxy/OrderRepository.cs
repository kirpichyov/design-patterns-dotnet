using DesignPatterns.Common.Contracts;
using DesignPatterns.Common.Models;

namespace DesignPatterns.Proxy;

public class OrderRepository : IOrderRepository
{
    public Task AddAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Order[] orders)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Order[]> GetForUserAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}