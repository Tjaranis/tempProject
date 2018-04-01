using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    public class PostType
    {
        public PostType()
        {
            Post = new HashSet<Post>();
        }

        public string TypeName { get; set; }

        public ICollection<Post> Post { get; set; }
    }
}
