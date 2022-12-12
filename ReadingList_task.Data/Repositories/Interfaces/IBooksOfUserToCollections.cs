using ReadingList_task.Data.Entities;

namespace ReadingList_task.Data.Repositories.Interfaces;

public interface IBooksOfUserToCollections
{
    public void DeleteCollection(int id);

    public void AddToDefaultCollection(int id);

    public void RemoveBookFromCollections(int id);
    
    public List<BooksOfUserToCollection> UpdateBookCollections(int id, ICollection<int> collectionIds);

}