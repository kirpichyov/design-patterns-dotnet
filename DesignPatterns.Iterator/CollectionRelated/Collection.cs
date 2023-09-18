using DesignPatterns.Iterator.IteratorRelated;

namespace DesignPatterns.Iterator.CollectionRelated;

public class Collection<T> : ICollection<T>
{
    private readonly List<T> _items = new();

    public void AddBook(T item)
    {
        _items.Add(item);
    }

    public IIterator<T> CreateIterator()
    {
        return new Iterator<T>(_items.ToArray());
    }

    public IIterator<T> CreateAlphabeticalIterator(Func<T, string> stringPropertyPicker)
    {
        // Bubble sort.
        var sortedItems = new List<T>(_items);
        for (var i = 0; i < sortedItems.Count - 1; i++)
        {
            for (var j = i + 1; j < sortedItems.Count; j++)
            {
                if (string.CompareOrdinal(stringPropertyPicker(sortedItems[i]), stringPropertyPicker(sortedItems[j])) > 0)
                {
                    (sortedItems[i], sortedItems[j]) = (sortedItems[j], sortedItems[i]);
                }
            }
        }

        return new Iterator<T>(sortedItems.ToArray());
    }
}