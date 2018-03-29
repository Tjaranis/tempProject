using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    internal partial class Answer
    {
        public int PostId { get; set; }
        public int? ParentId { get; set; }
        public sbyte? AcceptedAnswer { get; set; }
        public sbyte? Editable { get; set; }

        public Post Parent { get; set; }
    }
}
