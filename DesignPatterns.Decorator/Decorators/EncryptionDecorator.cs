namespace DesignPatterns.Decorator.Decorators;

public class EncryptionDecorator : DataSourceDecorator
{
    public EncryptionDecorator(DataSource dataSource) : base(dataSource)
    {
    }

    public override Task WriteData(string data)
    {
        var encrypted = Encrypt(data);
        base.WriteData(encrypted);
        
        return Task.CompletedTask;
    }

    public override async Task<string> ReadData()
    {
        var data = await base.ReadData();
        var decrypted = Decrypt(data);

        return decrypted;
    }

    private string Encrypt(string data)
    {
        return data + "+encrypted";
    }
    
    private string Decrypt(string data)
    {
        return data.Replace("+encrypted", string.Empty);
    }
}