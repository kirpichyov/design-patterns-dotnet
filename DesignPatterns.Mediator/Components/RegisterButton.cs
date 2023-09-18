namespace DesignPatterns.Mediator.Components;

public class RegisterButton : ComponentBase
{
    private bool _isEnabled = true;

    public void Click()
    {
        Console.WriteLine("Register button is clicked.");
        Mediator.Notify(this, EventType.Click, null);
    }

    public void Enable() => _isEnabled = true;
    public void Disable() => _isEnabled = false;
}