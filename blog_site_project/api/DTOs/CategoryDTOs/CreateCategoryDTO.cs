using System.ComponentModel.DataAnnotations;

namespace api.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Category Name is required!")]
        [MaxLength(20, ErrorMessage = "Category Name must no exceed 20 characters!")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
