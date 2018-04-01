using System;
using System.Collections.Generic;

namespace DataAccessLayer.PersistenceModels
{
    public class Question
    {
        public int PostId { get; set; }
        public sbyte? WasEdited { get; set; }
        public DateTime? ClosedDate { get; set; }
        public sbyte? Editable { get; set; }

        public Post Post { get; set; }
    }
}
