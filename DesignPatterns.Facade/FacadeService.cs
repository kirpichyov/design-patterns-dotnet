using System.Net;
using DesignPatterns.Common.Contracts;
using DesignPatterns.Common.Models;

namespace DesignPatterns.Facade;

public class FacadeService
{
    private readonly ICacheService _cacheService;
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IAuthContext _authContext;
    private readonly IOrdersMicroservice _ordersMicroservice;
    private readonly ILogger _logger;

    public FacadeService(
        ICacheService cacheService,
        IOrderRepository orderRepository,
        IMapper mapper,
        IAuthContext authContext,
        IOrdersMicroservice ordersMicroservice,
        ILogger logger)
    {
        _cacheService = cacheService;
        _orderRepository = orderRepository;
        _mapper = mapper;
        _authContext = authContext;
        _ordersMicroservice = ordersMicroservice;
        _logger = logger;
    }

    public async Task<OrderModel[]> GetOrdersAsync()
    {
        _authContext.EnsureUserHasOrdersViewPermission();
        
        var userId = _authContext.GetCurrentUserId();
        var cachedOrders = await _cacheService.TryGetAsync<Order[]>($"user-{userId}-orders");

        if (cachedOrders is not null)
        {
            return cachedOrders
                .OrderByDescending(order => order.CreatedAtUtc)
                .Select(order => _mapper.ToOrderModel(order))
                .ToArray();
        }

        var storedOrders =  await _orderRepository.GetForUserAsync(userId);

        if (storedOrders is not null)
        {
            await _cacheService.AddAsync($"user-{userId}-orders", storedOrders, TimeSpan.FromMinutes(30));
            
            return storedOrders
                .OrderByDescending(order => order.CreatedAtUtc)
                .Select(order => _mapper.ToOrderModel(order)).ToArray(); 
        }

        var response = await _ordersMicroservice.GetOrdersAsync(userId);

        if (response.StatusCode is HttpStatusCode.OK)
        {
            var mappedOrders = response.Data.Select(item => _mapper.ToOrder(item)).ToArray();
            
            await _orderRepository.AddAsync(mappedOrders);
            await _cacheService.AddAsync($"user-{userId}-orders", mappedOrders, TimeSpan.FromMinutes(30));
            
            return mappedOrders
                .OrderByDescending(order => order.CreatedAtUtc)
                .Select(order => _mapper.ToOrderModel(order)).ToArray(); 
        }

        _logger.LogError("Unable to retrieve orders for user {UserId} .", userId);
        return Array.Empty<OrderModel>();
    }
}