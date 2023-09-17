namespace DesignPatterns.Common;

public class DependencyInjection
{
    public static T ResolveRequired<T>() => default(T);
}