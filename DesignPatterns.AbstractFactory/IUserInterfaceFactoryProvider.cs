using DesignPatterns.AbstractFactory.Models;

namespace DesignPatterns.AbstractFactory;

public interface IUserInterfaceFactoryProvider
{
    IUserInterfaceFactory GetFor(OperatingSystemType systemType);
}