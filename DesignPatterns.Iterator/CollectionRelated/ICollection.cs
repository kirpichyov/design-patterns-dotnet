using DesignPatterns.Iterator.IteratorRelated;

namespace DesignPatterns.Iterator.CollectionRelated;

public interface ICollection<T>
{
    IIterator<T> CreateIterator();
    IIterator<T> CreateAlphabeticalIterator(Func<T, string> stringPropertyPicker);
}