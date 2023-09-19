namespace DesignPatterns.Strategy.ConcreteStrategies;

public class GpuReliesStrategy : IStrategy
{
    public void RenderPage()
    {
        Console.WriteLine("Rendering page using the algo that relies on GPU. High quality.");
    }
}