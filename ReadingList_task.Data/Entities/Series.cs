using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingList_task.Data.Entities
{
    public partial class Series
    {
        public Series()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }
        public string? SeriesName { get; set; }

        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }
    }
}
