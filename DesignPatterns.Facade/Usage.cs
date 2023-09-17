using DesignPatterns.Common;

namespace DesignPatterns.Facade;

public class Usage
{
    public static async Task Main()
    {
        var facade = DependencyInjection.ResolveRequired<FacadeService>();
        var orders = await facade.GetOrdersAsync();
    }
}