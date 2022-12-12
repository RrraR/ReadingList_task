using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingList_task.Data.Entities
{
    public partial class UserCollection
    {
        public UserCollection()
        {
            BooksOfUsersToCollections = new HashSet<BooksOfUserToCollection>();
        }
        [Key]
        public int Id { get; set; }
        public string CollectionName { get; set; } = null!;

        [NotMapped]
        public virtual ICollection<BooksOfUserToCollection> BooksOfUsersToCollections { get; set; }
    }
}
