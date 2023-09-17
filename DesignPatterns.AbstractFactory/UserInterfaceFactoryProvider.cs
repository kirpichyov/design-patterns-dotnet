using DesignPatterns.AbstractFactory.ConcreteFactories;
using DesignPatterns.AbstractFactory.Models;
using DesignPatterns.Common.Contracts;

namespace DesignPatterns.AbstractFactory;

public class UserInterfaceFactoryProvider : IUserInterfaceFactoryProvider
{
    private readonly IConfigProvider _configProvider;

    public UserInterfaceFactoryProvider(IConfigProvider configProvider)
    {
        _configProvider = configProvider;
    }

    public IUserInterfaceFactory GetFor(OperatingSystemType systemType)
    {
        return systemType switch
        {
            OperatingSystemType.Windows =>
                new WindowsFactory(
                    _configProvider.TryGet<string>("version"),
                    _configProvider.TryGet<bool>("dark")),
            OperatingSystemType.MacOS =>
                new MacOSFactory(
                    _configProvider.TryGet<float>("os_version"),
                    _configProvider.TryGet<string>("apple_id")),
            OperatingSystemType.Linux => new UnixFactory(RetrieveUnixCore()),
            _ => throw new ArgumentOutOfRangeException(nameof(systemType), systemType, null)
        };
    }

    private static IUnixCore RetrieveUnixCore()
    {
        // Some complex logic...
        return new DebianCore();
    }
    
    private sealed class DebianCore : IUnixCore
    {
    }
}