namespace api.Responses.PostResponses
{
    public class UpdatePostResponse
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }

    }
}
