using api.Context;
using api.DTOs.CategoryDTOs;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace api.Repositories.Implementations
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoriesRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }

        public async Task<int> CountCategories(string filter)
        {
            IQueryable<Category> categories = _dbSet;

            if (!string.IsNullOrEmpty(filter))
            {
                categories = categories.Where(_ => _.CategoryName.Contains(filter));
            }

            var categoriesCount = await categories.CountAsync();

            return categoriesCount;

        }

        public async Task CreateCategory(Category category)
        {
            category.CreatedAt = DateTime.Now.ToUniversalTime();
            await _dbSet.AddAsync(category);
        }

        public void DeleteCategory(Category category)
        {
            _dbSet.Remove(category);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _dbSet.ToListAsync();

            return categories;
        }

        public async Task<List<Category>> GetCategories(int page, int pageSize, string sortBy, string sortOrder, string filter)
        {
            IQueryable<Category> categories = _dbSet;

            if (!string.IsNullOrEmpty(filter))
            {
                categories = categories.Where(_ => _.CategoryName.Contains(filter));
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                string sortExpression = $"{sortBy} {sortOrder}";
                categories = categories.OrderBy(sortExpression);
            }

            categories = categories.Skip((page - 1) * pageSize).Take(pageSize);

            var categoriesToList = await categories.ToListAsync();

            return categoriesToList;
        }

        public async Task<Category?> GetCategory(int categoryId)
        {
            var category = await _dbSet.FirstOrDefaultAsync(_ => _.CategoryId == categoryId);

            return category;
        }

        public void UpdateCategory(Category category, UpdateCategoryDTO updateCategoryDTO)
        {
            category.UpdatedAt = DateTime.Now.ToUniversalTime();
            category.CategoryName = updateCategoryDTO.CategoryName;
        }

        public async Task SaveChangesInCategories()
        {
            await _context.SaveChangesAsync();
        }


    }
}
