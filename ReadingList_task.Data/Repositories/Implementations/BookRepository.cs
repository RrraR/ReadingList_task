using ReadingList_task.Data;
using ReadingList_task.Data.Entities;
using ReadingList_task.Data.Repositories.Interfaces;

namespace ReadingList_task.Data.Repositories.Implementations;

public class BooksRepository:IBookRepository
{
    private readonly ReadingListDbContext _dbContext;


    public BooksRepository(ReadingListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IList<Book> GetAllBooks()
    {
        return _dbContext.Books.ToList();
    }

    public Book GetBookById(int id)
    {
        return _dbContext.Books.FirstOrDefault(b => b.Id == id);
    }
}