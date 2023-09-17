namespace DesignPatterns.ChainOfResp;

public abstract class HttpRequestHandler : IHttpRequestHandler
{
    private IHttpRequestHandler _next;

    protected HttpRequestHandler(IHttpRequestHandler httpRequestHandler)
    {
        _next = httpRequestHandler;
    }
    
    public IHttpRequestHandler SetNext(IHttpRequestHandler httpRequestHandler)
    {
        _next = httpRequestHandler;
        return httpRequestHandler;
    }
    
    public virtual HttpRequest Handle(HttpRequest request)
    {
        if (request.IsHandled)
        {
            return request;
        }
        
        return _next?.Handle(request);
    }
}