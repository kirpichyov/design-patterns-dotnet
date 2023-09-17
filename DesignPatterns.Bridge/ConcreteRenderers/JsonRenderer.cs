namespace DesignPatterns.Bridge.ConcreteRenderers;

public class JsonRenderer : IDataRenderer
{
    public Task<string> RenderToStringAsync<T>(T[] data)
    {
        throw new NotImplementedException();
    }
}