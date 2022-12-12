namespace ReadingList_task.Services.ViewModels;

public class EditBookOfUserQuery
{
    public bool IsFinished { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? FinishDate { get; set; }
    public int ReadingPriority { get; set; }
    public ICollection<CollectionViewModel> Collections { get; set; }
}