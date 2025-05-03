using System.Xml.Linq;

namespace api.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<PostCategory> PostCategories { get; set; } = new List<PostCategory>();

    }
}
