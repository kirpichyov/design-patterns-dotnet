namespace DesignPatterns.Decorator.Decorators;

public class CompressionDecorator : DataSourceDecorator
{
    public CompressionDecorator(DataSource dataSource) : base(dataSource)
    {
    }

    public override Task WriteData(string data)
    {
        var encrypted = Compress(data);
        base.WriteData(encrypted);
        
        return Task.CompletedTask;
    }

    public override async Task<string> ReadData()
    {
        var data = await base.ReadData();
        var decrypted = Decompress(data);

        return decrypted;
    }

    private string Compress(string data)
    {
        return data + "+compressed";
    }
    
    private string Decompress(string data)
    {
        return data.Replace("+compressed", string.Empty);
    }
}