namespace api.DTOs.CommentDTOs
{
    public class ListCommentInDetailsPostDTO
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
