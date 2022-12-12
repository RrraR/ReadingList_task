using ReadingList_task.Data.Entities;

namespace ReadingList_task.Data.Repositories.Interfaces;

public interface IBookRepository
{
    public IList<Book> GetAllBooks();

    public Book GetBookById(int id);

}