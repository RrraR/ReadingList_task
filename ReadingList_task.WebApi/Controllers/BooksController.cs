using Microsoft.AspNetCore.Mvc;
using ReadingList_task.Services.Services.Interfaces;
using ReadingList_task.Services.ViewModels;

namespace ReadingList_task.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService service)
        {
            _bookService = service;
        }

        [HttpGet]
        public ICollection<BookOfUserOverviewViewModel> GetBookOverviews(string? collectionName, bool? showFinished)
        {
            var query = new GetBooksOfUserQuery()
            {
                CollectionName = collectionName,
                ShowFinished = showFinished
            };
            
            return _bookService.GetBookOfUserOverviewsFiltered(query);
        }

        [HttpGet("{id}")]
        public BookOfUserViewModel GetBook(int id)
        {
            return _bookService.GetBookOfUserInfo(id);
        }

        [HttpPost("{id}")]
        public void AddBookToBooksOfUser(int id)
        {
            _bookService.AddBookToBooksOfUser(id);
        }

        [HttpDelete("{id}")]
        public ICollection<BookOfUserOverviewViewModel> DeleteBookFromBooksOfUser(int id)
        {
            _bookService.DeleteBookFromBooksOfUser(id);
            return _bookService.GetBookOfUserOverviews();
        }

        [HttpPut("{id}")]
        public BookOfUserViewModel UpdateBook(int id, [FromBody]EditBookOfUserQuery book)
        {
            _bookService.UpdateBookInBooksOfuser(id, book);
            return _bookService.GetBookOfUserInfo(id);
        }
    }
}