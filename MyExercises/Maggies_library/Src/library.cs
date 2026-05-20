public class Library
{
    private List<Book> availableBooks = [];
    private List<Member> allMembers = [];
    private List<(Member, Book)> lentOutBooks = [];
    private Dictionary<Book, int> timesLentOut = [];
    public void AddBook(Book Title)
    {
        availableBooks.Add(Title);
        timesLentOut.Add(Title, 0);
    }
    public void AddMember(Member member)
    {
        allMembers.Add(member);
    }
    public void BorrowBook(Book title, Member member)
    {
        if (availableBooks.Contains(title) && allMembers.Contains(member))
        {
            availableBooks.Remove(title);
            lentOutBooks.Add((member, title));
            timesLentOut[title] += 1;
        }
        else throw new Exception("Book or member not valid");
    }
    public void CheckinBook(Book title, Member member)
    {
        if (lentOutBooks.Contains((member, title)))
        {
            lentOutBooks.Remove((member, title));
            availableBooks.Add(title);
        }
        else throw new Exception("Book or member not valid");
    }
    public List<Book> ShowAvailableBooks()
    {
        return availableBooks;
    }
    public List<(Book, int)> MostPopulairBooks()
    {
        return timesLentOut
            .Select(kv => (kv.Key, kv.Value))
            .OrderBy(t => t.Item2)
            .ToList();
    }
}