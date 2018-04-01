namespace DataTransferObjects.BusinessDataAccessDTOs
{
    public class NoteDTO
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public System.DateTime? CreationDate { get; set; }
        public string Body { get; set; }

        public PostDTO Post { get; set; }
        public StackOverflowUserDTO User { get; set; }
    }
}