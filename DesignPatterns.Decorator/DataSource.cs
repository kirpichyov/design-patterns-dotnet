namespace DesignPatterns.Decorator;

public abstract class DataSource
{
    public abstract Task WriteData(string data);
    public abstract Task<string> ReadData();
}