using DesignPatterns.Common.Contracts;

namespace DesignPatterns.ChainOfResp.Handlers;

public class LoggingHandler : HttpRequestHandler
{
    private readonly ILogger _logger;
    
    public LoggingHandler(ILogger logger, IHttpRequestHandler httpRequestHandler = null) : base(httpRequestHandler)
    {
        _logger = logger;
    }

    public override HttpRequest Handle(HttpRequest request)
    {
        _logger.LogInformation("Request from IP {0}", request.Ip.ToString());
        return base.Handle(request);
    }
}