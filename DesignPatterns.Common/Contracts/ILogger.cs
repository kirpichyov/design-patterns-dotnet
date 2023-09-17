namespace DesignPatterns.Common.Contracts;

public interface ILogger
{
    void LogError(string message, object arg1);
}