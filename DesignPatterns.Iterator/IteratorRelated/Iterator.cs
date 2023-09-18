namespace DesignPatterns.Iterator.IteratorRelated;

public class Iterator<T> : IIterator<T>
{
    private readonly T[] _items;
    private int _currentIndex = 0;

    public Iterator(T[] items)
    {
        _items = items;
    }

    public bool HasNext()
    {
        return _currentIndex < _items.Length;
    }

    public T Next()
    {
        return HasNext() ? _items[_currentIndex++] : default(T);
    }
}