using ReadingList_task.Services.ViewModels;

namespace ReadingList_task.Services.Services.Interfaces;

public interface ILibraryService
{
    public ICollection<LibraryBookOverviewsViewModel> GetLibraryBookOverviews();
    public LibraryBookViewModel GetLibraryBookInfo(int id);
}