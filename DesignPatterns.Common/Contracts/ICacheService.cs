namespace DesignPatterns.Common.Contracts;

public interface ICacheService
{
    Task<TData> AddAsync<TData>(string key, TData value, TimeSpan timeToLive);
    Task<TData> UpdateAsync<TData>(string key, TData value, TimeSpan timeToLive);
    Task<TData> UpdatePartialAsync<TData>(string key, TData value, Func<TData, bool> filter);
    Task RemoveAsync(string key);
    Task RemovePartialAsync<TData>(string key, Func<TData, bool> filter);
    Task<TData> TryGetAsync<TData>(string key);
}