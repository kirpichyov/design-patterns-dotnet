using DesignPatterns.AbstractFactory.Models;
using DesignPatterns.Common.Contracts;

namespace DesignPatterns.AbstractFactory;

public class Usage
{
    // In real world dependency is resolved via IoC/DI Container.
    public void Main(IConfigProvider windowsRegister)
    {
        var os = OperatingSystemType.Windows;
        var factoryProvider = new UserInterfaceFactoryProvider(windowsRegister);
        var uiFactory = factoryProvider.GetFor(os);

        var button = uiFactory.InstantiateButton("Click me!",
            "color: red; x: 15; y: 25.5;",
            args => Console.WriteLine("Clicked!"));
    }
}