using api.DTOs.CategoryDTOs;
using api.Models;

namespace api.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<List<Category>> GetCategories(int page, int pageSize, string sortBy, string sortOrder, string filter);
        Task<Category?> GetCategory(int categoryId);
        Task CreateCategory(Category category);
        void UpdateCategory(Category category, UpdateCategoryDTO updateCategoryDTO);
        void DeleteCategory(Category category);
        Task<int> CountCategories(string filter);
        Task<List<Category>> GetAllCategories();
        Task SaveChangesInCategories();
    }
}
