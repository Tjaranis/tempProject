﻿using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    public class Answer
    {
        public int PostId { get; set; }
        public int? ParentId { get; set; }
        public Int16? AcceptedAnswer { get; set; }
        public Int16? Editable { get; set; }

        public Post Parent { get; set; }
    }
}
