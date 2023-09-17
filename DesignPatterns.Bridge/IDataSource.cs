namespace DesignPatterns.Bridge;

public interface IDataSource
{
    Task<T[]> GetAsync<T>(string query);
}