namespace api.Responses.CategoryResponses
{
    public class UpdateCategoryResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
    }
}
