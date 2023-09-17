using DesignPatterns.AbstractFactory.Models;
using EventArgs = System.EventArgs;

namespace DesignPatterns.AbstractFactory.ConcreteFactories;

public class WindowsFactory : IUserInterfaceFactory
{
    public WindowsFactory(string version, bool isDark)
    {
    }
    
    public Button InstantiateButton(string text, string style, Action<EventArgs> onClick)
    {
        throw new NotImplementedException();
    }

    public Checkbox InstantiateCheckbox(string text, string style, bool defaultValue, Action<EventArgs> onChange)
    {
        throw new NotImplementedException();
    }

    public TextBox InstantiateTextBox(string text, string style, bool isReadonly, Action<EventArgs> onChange)
    {
        throw new NotImplementedException();
    }
}