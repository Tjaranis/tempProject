using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    internal partial class Tag
    {
        public Tag()
        {
            PostTag = new HashSet<PostTag>();
        }

        public string TagName { get; set; }

        public ICollection<PostTag> PostTag { get; set; }
    }
}
