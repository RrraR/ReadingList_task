using AutoMapper;
using Castle.Core.Internal;
using ReadingList_task.Data;
using ReadingList_task.Data.Entities;
using ReadingList_task.Data.Repositories.Interfaces;
using ReadingList_task.Services.Services.Interfaces;
using ReadingList_task.Services.ViewModels;

namespace ReadingList_task.Services.Services.Implementations;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IBooksOfUserRepository _booksOfUserRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IBooksOfUserToCollections _booksOfUserToCollections;


    public BookService(IMapper mapper, IBooksOfUserRepository booksOfUserRepository, IBookRepository bookRepository,
        IBooksOfUserToCollections booksOfUserToCollections)
    {
        _mapper = mapper;
        _booksOfUserRepository = booksOfUserRepository;
        _bookRepository = bookRepository;
        _booksOfUserToCollections = booksOfUserToCollections;
    }

    public ICollection<BookOfUserOverviewViewModel> GetBookOfUserOverviewsFiltered(GetBooksOfUserQuery query)
    {
        var booksOfUsers = _booksOfUserRepository.GetBooksOfUser().OrderBy(b => b.ReadingPriority);
        var t = _mapper.Map<ICollection<BookOfUserOverviewViewModel>>(booksOfUsers);
        if (!query.CollectionName.IsNullOrEmpty())
        {
            t = t.Where(x => x.Collections.Any(y => y.Name == query.CollectionName)).ToList();
        }

        if (query.ShowFinished.HasValue && query.ShowFinished.Value)
        {
            t = t.Where(x => x.IsFinished).ToList();
        }

        return t;
    }
    
    public ICollection<BookOfUserOverviewViewModel> GetBookOfUserOverviews()
    {
        var temp = _booksOfUserRepository.GetBooksOfUser();
        return _mapper.Map<ICollection<BookOfUserOverviewViewModel>>(temp);
    }

    public BookOfUserViewModel GetBookOfUserInfo(int id)
    {
        var temp = _booksOfUserRepository.GetBookOfUserById(id);
        var t =  _mapper.Map<BookOfUserViewModel>(temp);
        t.StartDate = DateOnly.FromDateTime(temp.StartReadingDate);
        if (temp.IsFinished)
        {
            t.FinishDate = DateOnly.FromDateTime(temp.FinishReadingDate.Value);
        }
        return t;
    }

    public void AddBookToBooksOfUser(int id)
    {
        var book = _bookRepository.GetBookById(id);
        var temp = new BooksOfUser()
        {
            FK_BookId = book.Id
        };
        //var temp = _mapper.Map<BooksOfUser>(book);
        _booksOfUserRepository.AddBook(temp);
    }

    public void DeleteBookFromBooksOfUser(int id)
    {
        var book = _booksOfUserRepository.GetBookOfUserById(id);
        _booksOfUserRepository.DeleteBook(book);
    }

    public void UpdateBookInBooksOfuser(int id, EditBookOfUserQuery updateBook)
    {
        var existingBook = _booksOfUserRepository.GetBookOfUserById(id);
        
        if (updateBook.IsFinished)
        {
            existingBook.IsFinished = true;
            existingBook.FinishReadingDate = updateBook.FinishDate.Value.ToDateTime(TimeOnly.MinValue);
        }
        else
        {
            existingBook.IsFinished = false;
            existingBook.FinishReadingDate = null;
        }

        existingBook.StartReadingDate = updateBook.StartDate.ToDateTime(TimeOnly.MinValue);
        existingBook.ReadingPriority = updateBook.ReadingPriority;
        existingBook.BooksOfUserToCollections = _booksOfUserToCollections.
            UpdateBookCollections(id, updateBook.Collections.Select(c => c.Id).ToList());
        _booksOfUserRepository.UpdateBook(existingBook);
    }
}