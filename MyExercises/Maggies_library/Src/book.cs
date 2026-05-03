using System.Dynamic;
using System.Runtime.CompilerServices;

public class Book
{
    public string Title { get; init; }
    public string Author { get; init; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}