using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    public class Tag
    {
        public Tag()
        {
            PostTag = new HashSet<PostTag>();
        }

        public string TagName { get; set; }

        public ICollection<PostTag> PostTag { get; set; }
    }
}
