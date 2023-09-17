namespace DesignPatterns.Bridge.ConcreteDataSources;

public class CsvDataSource : IDataSource
{
    public Task<T[]> GetAsync<T>(string query)
    {
        throw new NotImplementedException();
    }
}