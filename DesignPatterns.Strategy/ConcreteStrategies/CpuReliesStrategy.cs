namespace DesignPatterns.Strategy.ConcreteStrategies;

public class CpuReliesStrategy : IStrategy
{
    public void RenderPage()
    {
        Console.WriteLine("Rendering page using the algo that relies on CPU. Medium quality.");
    }
}