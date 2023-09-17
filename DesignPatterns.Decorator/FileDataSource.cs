namespace DesignPatterns.Decorator;

public class FileDataSource : DataSource
{
    public string Filename { get; init; }

    public FileDataSource(string filename)
    {
        Filename = filename;
    }
    
    public override Task WriteData(string data)
    {
        return Task.CompletedTask;
    }

    public override Task<string> ReadData()
    {
        return Task.FromResult("file content!");
    }
}