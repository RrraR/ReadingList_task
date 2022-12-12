using ReadingList_task.Data.Entities;
using ReadingList_task.Data.Repositories.Interfaces;

namespace ReadingList_task.Data.Repositories.Implementations;

public class CollectionRepository : ICollectionRepository
{
    private readonly ReadingListDbContext _dbContext;
    private readonly IBooksOfUserToCollections _booksOfUserToCollection;
    
    public CollectionRepository(ReadingListDbContext dbContext, IBooksOfUserToCollections booksOfUserToCollection)
    {
        _dbContext = dbContext;
        _booksOfUserToCollection = booksOfUserToCollection;
    }
    
    public IList<UserCollection> GetAllCollections()
    {
        return _dbContext.UserCollections.ToList();
    }

    public UserCollection GetCollection(int id)
    {
        return _dbContext.UserCollections.FirstOrDefault(c => c.Id == id);
    }

    public void AddNewCollection(UserCollection collection)
    {
        _dbContext.UserCollections.Add(collection);
        _dbContext.SaveChanges();
    }

    public void DeleteCollection(UserCollection collection)
    {
        _booksOfUserToCollection.DeleteCollection(collection.Id);
        _dbContext.UserCollections.Remove(collection);
        _dbContext.SaveChanges();
    }
}