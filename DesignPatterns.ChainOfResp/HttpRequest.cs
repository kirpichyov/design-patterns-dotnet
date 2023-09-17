using System.Net;

namespace DesignPatterns.ChainOfResp;

public record HttpRequest(IPAddress Ip, string ContentType, string Content, Dictionary<string, string> Headers, string RequestedPath)
{
    public void SetResponse(HttpStatusCode code, string content, string contentType)
    {
        IsHandled = true;
    }

    public bool IsHandled { get; private set; }
}