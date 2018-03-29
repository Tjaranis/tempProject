using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    internal partial class StackOverflowUser
    {
        public StackOverflowUser()
        {
            Bookmark = new HashSet<Bookmark>();
            Note = new HashSet<Note>();
            Post = new HashSet<Post>();
            PostComment = new HashSet<PostComment>();
            UserSearchHistory = new HashSet<UserSearchHistory>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Location { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Age { get; set; }

        public ICollection<Bookmark> Bookmark { get; set; }
        public ICollection<Note> Note { get; set; }
        public ICollection<Post> Post { get; set; }
        public ICollection<PostComment> PostComment { get; set; }
        public ICollection<UserSearchHistory> UserSearchHistory { get; set; }
    }
}
