public interface ILibraryFacade
{
    Guid RegisterBook(string title, string author);
    Guid RegisterMember(string name);

    void BorrowBook(Guid bookId, Guid memberId);
    void ReturnBook(Guid bookId, Guid memberId);

    IReadOnlyList<(Guid, string)> GetAvailableBooks();          // returns list of (book.id, book.title)
    IReadOnlyList<string> GetBorrowedBooks(Guid memberId);      // returns list of book titles
    IReadOnlyList<string> GetTopBorrowedBooks(int count);       // returns list of book titles
}