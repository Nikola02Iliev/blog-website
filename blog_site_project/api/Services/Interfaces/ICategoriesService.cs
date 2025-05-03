using api.DTOs.CategoryDTOs;
using api.Helpers;
using api.Models;

namespace api.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<CustomPagedResult<ListCategoryDTO>> GetPagedCategoriesAsync(int page, int pageSize, string sortBy, string sortOrder, string filter);
        Task<Category?> GetCategoryAsync(int categoryId);
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category, UpdateCategoryDTO updateCategoryDTO);
        Task DeleteCategoryAsync(Category category);
        Task<bool> CategoryExists(string categoryName);
        Task<(bool, int)> CategoriesExists(List<int> categoryIds);
    }
}
