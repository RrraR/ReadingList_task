using AutoMapper;
using ReadingList_task.Data.Entities;
using ReadingList_task.Data.Repositories.Interfaces;
using ReadingList_task.Services.Services.Interfaces;
using ReadingList_task.Services.ViewModels;

namespace ReadingList_task.Services.Services.Implementations;

public class CollectionService : ICollectionService
{
    private readonly IMapper _mapper;
    private readonly ICollectionRepository _collectionRepository;

    public CollectionService(IMapper mapper, ICollectionRepository collectionRepository)
    {
        _mapper = mapper;
        _collectionRepository = collectionRepository;
    }

    public ICollection<CollectionViewModel> GetAllCollections()
    {
        var collections = _collectionRepository.GetAllCollections();
        return _mapper.Map<ICollection<CollectionViewModel>>(collections);
    }

    public CollectionViewModel GetCollection(int id)
    {
        var collection = _collectionRepository.GetCollection(id);
        return new CollectionViewModel()
        {
            Id = collection.Id,
            Name = collection.CollectionName
        };
    }

    public ICollection<CollectionViewModel> AddNewCollection(string name)
    {
        var tag = new UserCollection()
        {
            CollectionName = name
        };
        _collectionRepository.AddNewCollection(tag);
        var tags = _collectionRepository.GetAllCollections();
        return _mapper.Map<ICollection<CollectionViewModel>>(tags);
    }

    public ICollection<CollectionViewModel> DeleteCollection(int id)
    {
        var collection = _collectionRepository.GetCollection(id);
        _collectionRepository.DeleteCollection(collection);
        var collections = _collectionRepository.GetAllCollections();
        return _mapper.Map<ICollection<CollectionViewModel>>(collections);
    }
}