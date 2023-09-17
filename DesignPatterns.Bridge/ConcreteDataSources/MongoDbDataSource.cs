namespace DesignPatterns.Bridge.ConcreteDataSources;

public class MongoDbDataSource : IDataSource
{
    public Task<T[]> GetAsync<T>(string query)
    {
        throw new NotImplementedException();
    }
}