
using ReadingList_task.Data.Entities;

namespace ReadingList_task.Data.Repositories.Interfaces;

public interface ICollectionRepository
{
    public IList<UserCollection> GetAllCollections();
    
    public UserCollection GetCollection(int id);
    
    public void AddNewCollection(UserCollection collection);

    public void DeleteCollection(UserCollection collection);
    
}