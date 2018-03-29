using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    public partial class PostTag
    {
        public string TagName { get; set; }
        public int PostId { get; set; }

        public Post Post { get; set; }
        public Tag TagNameNavigation { get; set; }
    }
}
