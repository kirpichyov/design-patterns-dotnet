namespace DesignPatterns.Decorator;

public class FileDataSource : DataSource
{
    public string Filename { get; init; }
    public string Content { get; private set; }

    public FileDataSource(string filename, string content)
    {
        Filename = filename;
        Content = content;
    }
    
    public override Task WriteData(string data)
    {
        Console.WriteLine("Writing to file...");
        Content = data;
        return Task.CompletedTask;
    }

    public override Task<string> ReadData()
    {
        Console.WriteLine("Reading from file...");
        return Task.FromResult(Content);
    }
}