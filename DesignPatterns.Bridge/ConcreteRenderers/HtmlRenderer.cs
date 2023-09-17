namespace DesignPatterns.Bridge.ConcreteRenderers;

public class HtmlRenderer : IDataRenderer
{
    public Task<string> RenderToStringAsync<T>(T[] data)
    {
        throw new NotImplementedException();
    }
}