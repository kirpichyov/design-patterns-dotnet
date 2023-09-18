using System.Net;

namespace DesignPatterns.Mediator;

public class ApiService
{
    private bool _isHealthy;
    
    public ApiService(bool isHealthy)
    {
        _isHealthy = isHealthy;
    }
    
    public HttpStatusCode SendRegisterRequest(object data)
    {
        Console.WriteLine("Sending request to API");
        return _isHealthy ? HttpStatusCode.OK : HttpStatusCode.ServiceUnavailable;
    }
}