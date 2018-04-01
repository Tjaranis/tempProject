using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.BusinessDataAccessDTOs
{
    public class AnswerDTO
    {
        public int PostId { get; set; }
        public int? ParentId { get; set; }
        public Int16? AcceptedAnswer { get; set; }
        public Int16? Editable { get; set; }

        public PostDTO Parent { get; set; }
    }
}
