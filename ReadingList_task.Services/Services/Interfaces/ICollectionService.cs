using ReadingList_task.Services.ViewModels;

namespace ReadingList_task.Services.Services.Interfaces;

public interface ICollectionService
{
    public ICollection<CollectionViewModel> GetAllCollections();
    
    public CollectionViewModel GetCollection(int id);

    public ICollection<CollectionViewModel> AddNewCollection(string name);

    public ICollection<CollectionViewModel> DeleteCollection(int id);
}