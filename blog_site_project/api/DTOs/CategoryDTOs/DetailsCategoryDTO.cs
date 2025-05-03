namespace api.DTOs.CategoryDTOs
{
    public class DetailsCategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
