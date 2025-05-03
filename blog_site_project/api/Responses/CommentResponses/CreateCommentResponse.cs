namespace api.Responses.CommentResponses
{
    public class CreateCommentResponse
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
