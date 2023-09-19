namespace DesignPatterns.Common.Contracts;

public interface ILogger
{
    void LogError(string message, object arg1);
    void LogInformation(string message, object arg1);
}

public class Logger : ILogger
{
    public void LogError(string message, object arg1)
    {
        Console.WriteLine("[ERROR] " + message, arg1);
    }

    public void LogInformation(string message, object arg1)
    {
        Console.WriteLine("[INFO] " + message, arg1);
    }
}