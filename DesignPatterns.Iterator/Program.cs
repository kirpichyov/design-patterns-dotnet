using DesignPatterns.Iterator.CollectionRelated;
using DesignPatterns.Iterator.IteratorRelated;

namespace DesignPatterns.Iterator;

public class Program
{
    public static void Main()
    {
        var bookCollection = new Collection<Book>();
        bookCollection.AddBook(new Book("1984", "George Orwell"));
        bookCollection.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));
        bookCollection.AddBook(new Book("Moby Dick", "Herman Melville"));

        IIterator<Book> iterator = bookCollection.CreateIterator();
        while (iterator.HasNext())
        {
            Book book = iterator.Next();
            Console.WriteLine($"{book.Title} by {book.Author}");
        }

        Console.WriteLine("\nAlphabetical Order:");
        IIterator<Book> alphabeticalIterator = bookCollection.CreateAlphabeticalIterator(book => book.Author);
        while (alphabeticalIterator.HasNext())
        {
            Book book = alphabeticalIterator.Next();
            Console.WriteLine($"{book.Title} by {book.Author}");
        }
    }
}

public class Book
{
    public string Title { get; }
    public string Author { get; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}