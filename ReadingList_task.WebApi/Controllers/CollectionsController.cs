using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingList_task.Services.Services.Interfaces;
using ReadingList_task.Services.ViewModels;

namespace ReadingList_task.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionService _collectionService;


        public CollectionsController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpGet]
        public ICollection<CollectionViewModel> GetAllColections()
        {
            return _collectionService.GetAllCollections();
        }
        
        [HttpGet("{id}")]
        public CollectionViewModel GetCollection(int id)
        {
            return _collectionService.GetCollection(id);
        }

        [HttpPost("name")]
        public ICollection<CollectionViewModel> AddCollection([FromBody] string name)
        {
            _collectionService.AddNewCollection(name);
            return _collectionService.GetAllCollections();
        }

        [HttpDelete("{id}")]
        public ICollection<CollectionViewModel> DeleteCollection(int id)
        {
            return _collectionService.DeleteCollection(id);
        }
        
    }
}
