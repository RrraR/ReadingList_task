using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingList_task.Data.Entities
{
    public partial class BooksOfUser
    {
        // public BooksOfUser()
        // {
        //     UserRatings = new HashSet<UserRating>();
        // }

        [Key]
        public int Id { get; set; }
        public int FK_BookId { get; set; }
        public int ReadingPriority { get; set; }
        public bool IsFinished { get; set; }
        public DateTime StartReadingDate { get; set; }
        public DateTime? FinishReadingDate { get; set; }

        [NotMapped]
        [ForeignKey("FK_BookId")]
        public virtual Book FK_Book { get; set; } = null!;
        
        [NotMapped]
        public virtual ICollection<BooksOfUserToCollection> BooksOfUserToCollections { get; set; }
        
    }
}
