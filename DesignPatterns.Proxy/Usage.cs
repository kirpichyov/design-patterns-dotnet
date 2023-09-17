using DesignPatterns.Common;
using DesignPatterns.Common.Contracts;

namespace DesignPatterns.Proxy;

public class Usage
{
    public static async Task Main()
    {
        var proxy = DependencyInjection.ResolveRequired<IOrderRepository>();
        var orders = await proxy.GetForUserAsync(Guid.NewGuid());
    }
}