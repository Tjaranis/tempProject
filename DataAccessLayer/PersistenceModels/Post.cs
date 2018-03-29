using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    public partial class Post
    {
        public Post()
        {
            Answer = new HashSet<Answer>();
            Bookmark = new HashSet<Bookmark>();
            Note = new HashSet<Note>();
            PostComment = new HashSet<PostComment>();
            PostLink = new HashSet<PostLink>();
            PostTag = new HashSet<PostTag>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int? Score { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string PostType { get; set; }

        public PostType PostTypeNavigation { get; set; }
        public StackOverflowUser User { get; set; }
        public Question Question { get; set; }
        public ICollection<Answer> Answer { get; set; }
        public ICollection<Bookmark> Bookmark { get; set; }
        public ICollection<Note> Note { get; set; }
        public ICollection<PostComment> PostComment { get; set; }
        public ICollection<PostLink> PostLink { get; set; }
        public ICollection<PostTag> PostTag { get; set; }
    }
}
