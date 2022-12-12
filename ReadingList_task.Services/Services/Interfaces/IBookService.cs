using ReadingList_task.Services.ViewModels;

namespace ReadingList_task.Services.Services.Interfaces;

public interface IBookService
{
    public ICollection<BookOfUserOverviewViewModel> GetBookOfUserOverviews();
    public ICollection<BookOfUserOverviewViewModel> GetBookOfUserOverviewsFiltered(GetBooksOfUserQuery query);
    public BookOfUserViewModel GetBookOfUserInfo(int id);

    public void AddBookToBooksOfUser(int id);

    public void DeleteBookFromBooksOfUser(int id);

    public void UpdateBookInBooksOfuser(int id, EditBookOfUserQuery updateBook);

}