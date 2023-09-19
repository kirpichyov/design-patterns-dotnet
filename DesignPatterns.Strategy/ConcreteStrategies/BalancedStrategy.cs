namespace DesignPatterns.Strategy.ConcreteStrategies;

public class BalancedStrategy : IStrategy
{
    public void RenderPage()
    {
        Console.WriteLine("Rendering frame using the balanced algo. Low quality.");
    }
}