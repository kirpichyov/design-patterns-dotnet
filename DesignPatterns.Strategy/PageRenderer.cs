namespace DesignPatterns.Strategy;

public class PageRenderer
{
    private IStrategy _renderStrategy;

    public PageRenderer(IStrategy renderStrategy = null)
    {
        _renderStrategy = renderStrategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _renderStrategy = strategy;
    }

    public void Render()
    {
        Console.WriteLine("Call system drivers.");
        Console.WriteLine("Build frame map.");
        _renderStrategy.RenderPage();
        Console.WriteLine("Clean up frame buffer.");
    }
}