using ReadingList_task.Data.Entities;
using ReadingList_task.Data.Repositories.Interfaces;

namespace ReadingList_task.Data.Repositories.Implementations;

public class BooksOfUserToCollections : IBooksOfUserToCollections
{
    private readonly ReadingListDbContext _dbContext;

    public BooksOfUserToCollections(ReadingListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void DeleteCollection(int id)
    {
        var temp = _dbContext.BooksOfUserToCollections.ToList();
        foreach (var item in temp)
        {
            _dbContext.BooksOfUserToCollections.Remove(item);
        }
        _dbContext.SaveChanges();
    }

    public void AddToDefaultCollection(int id)
    {
        var temp = new BooksOfUserToCollection()
        {
            FK_CollectionId = 1,
            FK_BookOfUserId = id
        };
        _dbContext.BooksOfUserToCollections.Add(temp);
        _dbContext.SaveChanges();
    }

    public void RemoveBookFromCollections(int id)
    {
        var temp = _dbContext.BooksOfUserToCollections.Where(b => b.FK_BookOfUserId == id).ToList();
        foreach (var item in temp)
        {
            _dbContext.BooksOfUserToCollections.Remove(item);
        }
        _dbContext.SaveChanges();
    }

    public List<BooksOfUserToCollection> UpdateBookCollections(int id, ICollection<int> collectionIds)
    {
        RemoveBookFromCollections(id);
        foreach (var item in collectionIds)
        {
            _dbContext.BooksOfUserToCollections.Add
            (
                new BooksOfUserToCollection()
                {
                    FK_CollectionId = item,
                    FK_Collection = _dbContext.UserCollections.FirstOrDefault(c=>c.Id == item),
                    FK_BookOfUserId = id
                }
            );
        }
        _dbContext.SaveChanges();
        return _dbContext.BooksOfUserToCollections.Where(c => c.FK_BookOfUserId == id).ToList();
    }
}