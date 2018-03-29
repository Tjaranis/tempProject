using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    internal partial class SearchHistory
    {
        public SearchHistory()
        {
            UserSearchHistory = new HashSet<UserSearchHistory>();
        }

        public string InputText { get; set; }

        public ICollection<UserSearchHistory> UserSearchHistory { get; set; }
    }
}
