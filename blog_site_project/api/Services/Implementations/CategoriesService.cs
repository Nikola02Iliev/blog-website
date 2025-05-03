using api.DTOs.CategoryDTOs;
using api.Helpers;
using api.Mappers;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services.Implementations
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<bool> CategoryExists(string categoryName)
        {
            var allCategories = await _categoriesRepository.GetAllCategories();

            if (allCategories.Any(_ => _.CategoryName == categoryName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<(bool, int)> CategoriesExists(List<int> categoryIds)
        {
            var allCategories = await _categoriesRepository.GetAllCategories();

            var allCategoriesIds = allCategories.Select(_ => _.CategoryId).ToList();

            foreach (var categoryId in categoryIds)
            {
                if (allCategoriesIds.Contains(categoryId))
                {
                    continue;
                }
                else
                {
                    return (false, categoryId);
                }
            }

            return (true, 1);
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _categoriesRepository.CreateCategory(category);
            await _categoriesRepository.SaveChangesInCategories();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            _categoriesRepository.DeleteCategory(category);
            await _categoriesRepository.SaveChangesInCategories();
        }

        public async Task<Category?> GetCategoryAsync(int categoryId)
        {
            var category = await _categoriesRepository.GetCategory(categoryId);

            return category;
        }

        public async Task<CustomPagedResult<ListCategoryDTO>> GetPagedCategoriesAsync(int page, int pageSize, string sortBy, string sortOrder, string filter)
        {
            var categories = await _categoriesRepository.GetCategories(page, pageSize, sortBy, sortOrder, filter);

            var toListCategoryDTOs = categories.Select(_ => _.ToListCategoryDTO()).ToList();

            var totalCategories = await _categoriesRepository.CountCategories(filter);

            var pagedCategories = new CustomPagedResult<ListCategoryDTO>
            {
                Data = toListCategoryDTOs,
                TotalCount = totalCategories,
                Page = page,
                PageSize = pageSize
            };

            return pagedCategories;

        }

        public async Task UpdateCategoryAsync(Category category, UpdateCategoryDTO updateCategoryDTO)
        {
            _categoriesRepository.UpdateCategory(category, updateCategoryDTO);
            await _categoriesRepository.SaveChangesInCategories();
        }
    }
}
