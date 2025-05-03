namespace api.Responses.CommentResponses
{
    public class UpdateCommentResponse
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
    }
}
