using ReadingList_task.Data.Entities;

namespace ReadingList_task.Data.Repositories.Interfaces;

public interface IBooksOfUserRepository
{
    public IList<BooksOfUser> GetBooksOfUser();

    public BooksOfUser GetBookOfUserById(int id);

    public bool CheckIfBookIsInBooksOfUser(int id);

    public void AddBook(BooksOfUser book);

    public void DeleteBook(BooksOfUser book);

    public void UpdateBook(BooksOfUser book);
}