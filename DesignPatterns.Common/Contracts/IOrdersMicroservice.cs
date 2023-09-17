using System.Net;
using DesignPatterns.Common.Models;

namespace DesignPatterns.Common.Contracts;

public interface IOrdersMicroservice
{
    Task<OrdersMicroserviceApiResponse<OrderResponse[]>> GetOrdersAsync(Guid userId);

    public record OrdersMicroserviceApiResponse<T>(HttpStatusCode StatusCode, T Data);
}