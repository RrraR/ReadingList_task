using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingList_task.Data.Entities
{
    public partial class Book
    {
        // public Book()
        // {
        //     BooksOfUsers = new HashSet<BooksOfUser>();
        // }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Length { get; set; }
        public string Language { get; set; } = null!;
        public int FK_AuthorId { get; set; }
        public int FK_GenreId { get; set; }
        public int? FK_SeriesId { get; set; }

        [NotMapped]
        [ForeignKey("FK_AuthorId")]
        public virtual Author FK_Author { get; set; } = null!;
        [NotMapped]
        [ForeignKey("FK_GenreId")]
        public virtual Genre FK_Genre { get; set; } = null!;
        [NotMapped]
        [ForeignKey("FK_SeriesId")]
        public virtual Series? FK_Series { get; set; }
        
        [NotMapped]
        public virtual BooksOfUser BooksOfUsers { get; set; }
    }
}
