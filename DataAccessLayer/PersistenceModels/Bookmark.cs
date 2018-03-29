using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    public partial class Bookmark
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime? CreationDate { get; set; }

        public Post Post { get; set; }
        public StackOverflowUser User { get; set; }
    }
}
