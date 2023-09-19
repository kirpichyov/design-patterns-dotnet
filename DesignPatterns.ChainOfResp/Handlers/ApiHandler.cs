using System.Net;

namespace DesignPatterns.ChainOfResp.Handlers;

public class ApiHandler : HttpRequestHandler
{
    public ApiHandler(IHttpRequestHandler httpRequestHandler = null) : base(httpRequestHandler)
    {
    }

    public override HttpRequest Handle(HttpRequest request)
    {
        request.SetResponse(HttpStatusCode.OK, """{ responseData: "some data" }""", "application/json");
        
        return base.Handle(request);
    }
}