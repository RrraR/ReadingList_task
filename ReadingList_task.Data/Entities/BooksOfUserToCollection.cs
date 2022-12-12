using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingList_task.Data.Entities;

public class BooksOfUserToCollection
{
    [Key]
    public int Id { get; set; }
    
    public int FK_CollectionId { get; set; }
    
    [NotMapped]
    [ForeignKey("FK_CollectionId")]
    public virtual UserCollection FK_Collection { get; set; }
    
    public int FK_BookOfUserId { get; set; }
    
    [NotMapped]
    [ForeignKey("FK_BookOfUserId")]
    public virtual BooksOfUser FK_BookOfUser { get; set; }
    
}