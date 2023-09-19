using System.Net;
using DesignPatterns.ChainOfResp.Handlers;
using DesignPatterns.Common.Contracts;
using FakeItEasy;

namespace DesignPatterns.ChainOfResp;

public class Usage
{
    public static void Main()
    {
        #region SetupDemo

        var cacheService = new Fake<ICacheService>();
        cacheService.CallsTo(x => x.TryGetAsync<string>($"endpoints-GET /api/v1/orders?cached"))
            .Returns(Task.FromResult("""{ "cachedResponse": 1234 }"""));

        #endregion
        
        var request = new HttpRequest(
            IPAddress.Loopback,
            "application/json",
            """{ "value": "some-value" }""",
            new Dictionary<string, string>()
            {
                { "Authorization", "Bearer ..." },
            },
            "GET /api/v1/orders");
        
        var requestCached = new HttpRequest(
            IPAddress.Loopback,
            "application/json",
            """{ "value": "some-value" }""",
            new Dictionary<string, string>()
            {
                { "Authorization", "Bearer ..." },
            },
            "GET /api/v1/orders?cached");
        
        var requestUnauthorized = new HttpRequest(
            IPAddress.Loopback,
            "application/json",
            """{ "value": "some-value" }""",
            new Dictionary<string, string>(),
            "GET /api/v1/orders");

        var pipeline = new AuthHandler();
        var loggingHandler = new LoggingHandler(new Logger());
        var cacheHandler = new CacheHandler(cacheService.FakedObject);
        var apiHandler = new ApiHandler();
        
        pipeline
            .SetNext(loggingHandler)
            .SetNext(cacheHandler)
            .SetNext(apiHandler);

        var result = pipeline.Handle(request);
        Console.WriteLine(result.Response);

        Console.WriteLine();
        
        var result2 = pipeline.Handle(requestCached);
        Console.WriteLine(result2.Response);

        Console.WriteLine();

        var result3 = pipeline.Handle(requestUnauthorized);
        Console.WriteLine(result3.Response);
    }
}