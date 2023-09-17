namespace DesignPatterns.ChainOfResp;

public interface IHttpRequestHandler
{
    IHttpRequestHandler SetNext(IHttpRequestHandler httpRequestHandler);
    HttpRequest Handle(HttpRequest request);
}