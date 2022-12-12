namespace ReadingList_task.Services.ViewModels;

public class LibraryBookViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public string Language { get; set; }
    public string Genre { get; set; }
    public string Series { get; set; }
    public bool IsInBooksOfUser { get; set; }
    
    public int? UserBookId { get; set; }
}