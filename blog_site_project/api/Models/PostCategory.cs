namespace api.Models
{
    public class PostCategory
    {
        public int PostCategoryId { get; set; }
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public Post? Post { get; set; }
        public Category? Category { get; set; }
    }
}
