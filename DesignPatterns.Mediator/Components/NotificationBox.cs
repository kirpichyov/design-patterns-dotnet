namespace DesignPatterns.Mediator.Components;

public class NotificationBox
{
    private bool _isShown = false;

    public void Show(string text)
    {
        Console.WriteLine("[NOTIFICATION]: " + text);
        _isShown = true;
    }

    public void Hide() => _isShown = false;
}