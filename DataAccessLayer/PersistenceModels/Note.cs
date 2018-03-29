using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    internal partial class Note
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Body { get; set; }

        public Post Post { get; set; }
        public StackOverflowUser User { get; set; }
    }
}
