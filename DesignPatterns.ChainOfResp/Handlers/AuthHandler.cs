using System.Net;

namespace DesignPatterns.ChainOfResp.Handlers;

public class AuthHandler : HttpRequestHandler
{
    public AuthHandler(IHttpRequestHandler httpRequestHandler = null) : base(httpRequestHandler)
    {
    }

    public override HttpRequest Handle(HttpRequest request)
    {
        if (!request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            request.SetResponse(HttpStatusCode.Unauthorized, "Auth required", "text/plain");
        }

        if (!ValidateHeader(authHeader))
        {
            request.SetResponse(HttpStatusCode.Unauthorized, "Auth failed", "text/plain");
        }
        
        return base.Handle(request);
    }

    private bool ValidateHeader(string value)
    {
        // Some logic here.
        return true;
    }
}