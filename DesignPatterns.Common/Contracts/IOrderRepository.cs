using DesignPatterns.Common.Models;

namespace DesignPatterns.Common.Contracts;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(Guid id);
}