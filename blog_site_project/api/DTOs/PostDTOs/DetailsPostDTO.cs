using api.DTOs.CategoryDTOs;
using api.DTOs.CommentDTOs;

namespace api.DTOs.PostDTOs
{
    public class DetailsPostDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<ListCommentInDetailsPostDTO> Comments { get; set; } = new List<ListCommentInDetailsPostDTO>();
        public List<ListCategoryDTOInDetailsPostDTO> Categories { get; set; } = new List<ListCategoryDTOInDetailsPostDTO>();

    }
}
