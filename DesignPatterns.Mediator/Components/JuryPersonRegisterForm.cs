namespace DesignPatterns.Mediator.Components;

public class JuryPersonRegisterForm : ComponentBase
{
    private readonly Dictionary<string, string> _data = new();
    private bool _isShown = false;

    public void Show()
    {
        Console.WriteLine($"{nameof(JuryPersonRegisterForm)} is shown.");
        _isShown = true;
    }
    
    public void Hide()
    {
        if (!_isShown)
        {
            return;
        }
        
        Console.WriteLine($"{nameof(JuryPersonRegisterForm)} is hidden.");
        _isShown = false;
    }

    public void Submit()
    {
        Console.WriteLine($"{nameof(JuryPersonRegisterForm)} submitted.");
        var isValid = ValidateForm();
        Mediator.Notify(this, EventType.Submit, (IsValid: isValid, Data: _data));
    }

    private bool ValidateForm()
    {
        return Random.Shared.Next(0, 2) == 1;
    }
}