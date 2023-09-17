namespace DesignPatterns.Bridge;

public interface IDataRenderer
{
    Task<string> RenderToStringAsync<T>(T[] data);
}