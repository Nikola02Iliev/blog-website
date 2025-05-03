using System.ComponentModel.DataAnnotations;

namespace api.DTOs.CommentDTOs
{
    public class UpdateCommentDTO
    {
        [Required(ErrorMessage = "Comment Text is required!")]
        [MaxLength(500, ErrorMessage = "Comment Text must no exceed 500 characters!")]
        public string CommentText { get; set; } = string.Empty;

    }
}
