namespace DesignPatterns.Decorator;

public abstract class DataSourceDecorator : DataSource
{
    private readonly DataSource _dataSource;

    public DataSourceDecorator(DataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public override Task WriteData(string data) => _dataSource?.WriteData(data);
    public override Task<string> ReadData() => _dataSource?.ReadData();
}