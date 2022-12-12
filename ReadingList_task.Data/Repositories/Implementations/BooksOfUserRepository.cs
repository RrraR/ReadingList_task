using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ReadingList_task.Data;
using ReadingList_task.Data.Entities;
using ReadingList_task.Data.Repositories.Interfaces;

namespace ReadingList_task.Data.Repositories.Implementations;

public class BooksOfUserRepository : IBooksOfUserRepository
{
    private readonly ReadingListDbContext _dbContext;
    private readonly IBooksOfUserToCollections _booksOfUserToCollections;

    public BooksOfUserRepository(ReadingListDbContext context, IBooksOfUserToCollections booksOfUserToCollections)
    {
        _dbContext = context;
        _booksOfUserToCollections = booksOfUserToCollections;
    }

    public IList<BooksOfUser> GetBooksOfUser()
    {
        var result = _dbContext.BooksOfUsers.Include(x => x.BooksOfUserToCollections).ThenInclude(x => x.FK_Collection)
            .ToList();

        return result;
    }

    public BooksOfUser GetBookOfUserById(int id)
    {
        return _dbContext.BooksOfUsers.FirstOrDefault(b => b.Id == id);
    }

    public void AddBook(BooksOfUser book)
    {
        _dbContext.BooksOfUsers.Add(book);
        _dbContext.SaveChanges();
        var b = _dbContext.BooksOfUsers.FirstOrDefault(g => g.FK_Book == book.FK_Book);
        _booksOfUserToCollections.AddToDefaultCollection(b.Id);
    }

    public bool CheckIfBookIsInBooksOfUser(int id)
    {
        return _dbContext.BooksOfUsers.Any(b => b.FK_BookId == id);
    }

    public void DeleteBook(BooksOfUser book)
    {
        _booksOfUserToCollections.RemoveBookFromCollections(book.Id);
        _dbContext.BooksOfUsers.Remove(book);
        _dbContext.SaveChanges();
    }

    public void UpdateBook(BooksOfUser book)
    {
        _dbContext.SaveChanges();
    }
}