using api.DTOs.CategoryDTOs;

namespace api.DTOs.PostDTOs
{
    public class ListPostDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<ListCategoryDTOInListPostDTO> Categories { get; set; } = new List<ListCategoryDTOInListPostDTO>();
    }
}
