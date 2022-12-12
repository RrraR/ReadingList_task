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
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _service;

        public LibraryController(ILibraryService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public ICollection<LibraryBookOverviewsViewModel> GetLibraryBookOverviews()
        {
            return _service.GetLibraryBookOverviews();
        }
        
        [HttpGet("{id}")]
        public LibraryBookViewModel GetLibraryBook(int id)
        {
            return _service.GetLibraryBookInfo(id);
        }
        

    }
}
