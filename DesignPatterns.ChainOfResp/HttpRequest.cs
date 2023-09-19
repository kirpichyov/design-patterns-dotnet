using System.Net;

namespace DesignPatterns.ChainOfResp;

public record HttpRequest(IPAddress Ip, string ContentType, string Content, Dictionary<string, string> Headers, string RequestedPath)
{
    public void SetResponse(HttpStatusCode code, string content, string contentType)
    {
        IsHandled = true;
        Response = (code, content, contentType);
    }

    public bool IsHandled { get; private set; } = false;
    public (HttpStatusCode? Code, string Content, string ContentType) Response { get; private set; }
}