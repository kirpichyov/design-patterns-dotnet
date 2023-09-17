using System.Net;
using DesignPatterns.ChainOfResp.Handlers;
using DesignPatterns.Common;

namespace DesignPatterns.ChainOfResp;

public class Usage
{
    public static void Main()
    {
        var request = new HttpRequest(
            IPAddress.Loopback,
            "application/json",
            """{ "value": "some-value" }""",
            new Dictionary<string, string>()
            {
                { "Authorization", "Bearer ..." },
            },
            "GET /api/v1/orders");

        var authHandler = DependencyInjection.ResolveRequired<AuthHandler>();
        var loggingHandler = DependencyInjection.ResolveRequired<LoggingHandler>();
        var cacheHandler = DependencyInjection.ResolveRequired<CacheHandler>();
        
        var pipeline = authHandler
            .SetNext(loggingHandler)
            .SetNext(cacheHandler);

        var result = pipeline.Handle(request);
    }
}