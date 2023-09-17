namespace DesignPatterns.Bridge.ConcreteDataSources;

public class PostgreSqlDbDataSource : IDataSource
{
    public Task<T[]> GetAsync<T>(string query)
    {
        throw new NotImplementedException();
    }
}