namespace DesignPatterns.Common.Contracts;

public interface IConfigProvider
{
    TValue TryGet<TValue>(string key);
}