using DesignPatterns.Common.Contracts;

namespace DesignPatterns.ChainOfResp.Handlers;

public class LoggingHandler : HttpRequestHandler
{
    private readonly ILogger _logger;
    
    public LoggingHandler(IHttpRequestHandler httpRequestHandler, ILogger logger) : base(httpRequestHandler)
    {
        _logger = logger;
    }

    public override HttpRequest Handle(HttpRequest request)
    {
        _logger.LogInformation("Request from IP {Ip}", request.Ip.ToString());
        return base.Handle(request);
    }
}