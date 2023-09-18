namespace DesignPatterns.Mediator.Components;

public class Loader
{
    private bool _isLoading = false;

    public void Run()
    {
        Console.WriteLine("Loader is shown.");
        _isLoading = true;
    }

    public void Stop()
    {
        Console.WriteLine("Loader is hidden.");
        _isLoading = false;
    }
}