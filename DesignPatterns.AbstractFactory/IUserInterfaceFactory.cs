using DesignPatterns.AbstractFactory.Models;
using EventArgs = System.EventArgs;

namespace DesignPatterns.AbstractFactory;

public interface IUserInterfaceFactory
{
    Button InstantiateButton(string text, string style, Action<EventArgs> onClick);
    Checkbox InstantiateCheckbox(string text, string style, bool defaultValue, Action<EventArgs> onChange);
    TextBox InstantiateTextBox(string text, string style, bool isReadonly, Action<EventArgs> onChange);
}