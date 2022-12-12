namespace ReadingList_task.Services.ViewModels;

public class GetBooksOfUserQuery
{
    public string CollectionName { get; set; }
    public bool? ShowFinished { get; set; }
}