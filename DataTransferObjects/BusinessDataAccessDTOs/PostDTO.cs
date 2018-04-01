using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.BusinessDataAccessDTOs
{
    public class PostDTO
    {//not made yet
        public PostDTO()
        {
            Answer = new HashSet<AnswerDTO>();
            Bookmark = new HashSet<BookmarkDTO>();
            Note = new HashSet<NoteDTO>();
            PostComment = new HashSet<PostCommentDTO>();
            PostLink = new HashSet<PostLinkDTO>();
            PostTag = new HashSet<PostTagDTO>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int? Score { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string PostType { get; set; }

        public PostTypeDTO PostTypeNavigation { get; set; }
        public StackOverflowUserDTO User { get; set; }
        public QuestionDTO Question { get; set; }
        public IEnumerable<AnswerDTO> Answer { get; set; }
        public IEnumerable<BookmarkDTO> Bookmark { get; set; }
        public IEnumerable<NoteDTO> Note { get; set; }
        public IEnumerable<PostCommentDTO> PostComment { get; set; }
        public IEnumerable<PostLinkDTO> PostLink { get; set; }
        public IEnumerable<PostTagDTO> PostTag { get; set; }
    }
}
