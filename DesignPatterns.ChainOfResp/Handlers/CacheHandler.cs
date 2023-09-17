using System.Net;
using DesignPatterns.Common.Contracts;

namespace DesignPatterns.ChainOfResp.Handlers;

public class CacheHandler : HttpRequestHandler
{
    private readonly ICacheService _cacheService;
    
    public CacheHandler(IHttpRequestHandler httpRequestHandler, ICacheService cacheService) : base(httpRequestHandler)
    {
        _cacheService = cacheService;
    }

    public override HttpRequest Handle(HttpRequest request)
    {
        var cache = _cacheService.TryGetAsync<string>($"endpoints-{request.RequestedPath}").GetAwaiter().GetResult();
        
        if (cache is not null)
        {
            request.SetResponse(HttpStatusCode.OK, cache, "application/json");
        }
        
        return base.Handle(request);
    }
}