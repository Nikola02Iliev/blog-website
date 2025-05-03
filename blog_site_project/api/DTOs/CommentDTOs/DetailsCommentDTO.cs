namespace api.DTOs.CommentDTOs
{
    public class DetailsCommentDTO
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        //public Post? Post {get; set;} 

    }
}
