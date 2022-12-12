using AutoMapper;
using ReadingList_task.Data.Repositories.Interfaces;
using ReadingList_task.Services.Services.Interfaces;
using ReadingList_task.Services.ViewModels;

namespace ReadingList_task.Services.Services.Implementations;

public class LibraryService : ILibraryService
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    private readonly IBooksOfUserRepository _booksOfUserRepository;

    public LibraryService(IBookRepository bookRepository, IMapper mapper, IBooksOfUserRepository booksOfUserRepository)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _booksOfUserRepository = booksOfUserRepository;
    }

    public ICollection<LibraryBookOverviewsViewModel> GetLibraryBookOverviews()
    {
        var temp = _bookRepository.GetAllBooks();
        var t = _mapper.Map<ICollection<LibraryBookOverviewsViewModel>>(temp);
        return t.OrderBy(c => c.Author).ToList();
    }

    public LibraryBookViewModel GetLibraryBookInfo(int id)
    {
        var book = _bookRepository.GetBookById(id);
        var model = _mapper.Map<LibraryBookViewModel>(book);
        model.IsInBooksOfUser = _booksOfUserRepository.CheckIfBookIsInBooksOfUser(book.Id);
        return model;
    }
}