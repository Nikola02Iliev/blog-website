namespace api.DTOs.CommentDTOs
{
    public class ListCommentDTO
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

    }
}
