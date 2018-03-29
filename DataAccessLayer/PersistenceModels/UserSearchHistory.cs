using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    internal partial class UserSearchHistory
    {
        public string SearchText { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }

        public SearchHistory SearchTextNavigation { get; set; }
        public StackOverflowUser User { get; set; }
    }
}
