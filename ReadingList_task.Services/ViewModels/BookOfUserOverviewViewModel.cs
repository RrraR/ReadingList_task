namespace ReadingList_task.Services.ViewModels;

public class BookOfUserOverviewViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int ReadingPriority { get; set; }
    public bool IsFinished { get; set; }
    public ICollection<CollectionViewModel> Collections { get; set; }
}