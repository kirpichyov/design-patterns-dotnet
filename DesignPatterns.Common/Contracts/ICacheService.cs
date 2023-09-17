namespace DesignPatterns.Common.Contracts;

public interface ICacheService
{
    Task<TData> AddAsync<TData>(string key, TData value, TimeSpan timeToLive);
    Task<TData> UpdateAsync<TData>(string key, TData value, TimeSpan timeToLive);
    Task RemoveAsync(string key);
}