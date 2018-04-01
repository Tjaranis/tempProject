using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    public class PostComment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int? Score { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? PostId { get; set; }

        public Post Post { get; set; }
        public StackOverflowUser User { get; set; }
    }
}
