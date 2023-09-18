namespace DesignPatterns.Iterator.IteratorRelated;

public interface IIterator<T>
{
    bool HasNext();
    T Next();
}