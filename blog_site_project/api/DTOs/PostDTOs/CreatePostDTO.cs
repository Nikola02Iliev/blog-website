using System.ComponentModel.DataAnnotations;

namespace api.DTOs.PostDTOs
{
    public class CreatePostDTO
    {
        [Required(ErrorMessage = "Title is required!")]
        [MaxLength(30, ErrorMessage = "Title must no exceed 30 characters!")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required!")]
        [MaxLength(2000, ErrorMessage = "Content must no exceed 2000 characters!")]
        public string Content { get; set; } = string.Empty;
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
