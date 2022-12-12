using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingList_task.Data.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        [Key] 
        public int Id { get; set; }
        public string GenreName { get; set; } = null!;
        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }
    }
}