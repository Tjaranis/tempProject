﻿using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    internal partial class PostLink
    {
        public int DuplicatedPostId { get; set; }
        public int ReferencePostId { get; set; }

        public Post DuplicatedPost { get; set; }
    }
}
