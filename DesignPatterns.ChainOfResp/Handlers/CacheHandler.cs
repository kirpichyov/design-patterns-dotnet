using System.Net;
using DesignPatterns.Common.Contracts;

namespace DesignPatterns.ChainOfResp.Handlers;

public class CacheHandler : HttpRequestHandler
{
    private readonly ICacheService _cacheService;
    
    public CacheHandler(ICacheService cacheService, IHttpRequestHandler httpRequestHandler = null) : base(httpRequestHandler)
    {
        _cacheService = cacheService;
    }

    public override HttpRequest Handle(HttpRequest request)
    {
        var cache = _cacheService.TryGetAsync<string>($"endpoints-{request.RequestedPath}").GetAwaiter().GetResult();
        
        if (!string.IsNullOrEmpty(cache))
        {
            request.SetResponse(HttpStatusCode.OK, cache, "application/json");
        }
        
        return base.Handle(request);
    }
}