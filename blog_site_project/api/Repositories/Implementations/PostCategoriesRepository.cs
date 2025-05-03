using api.Context;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations
{
    public class PostCategoriesRepository : IPostCategoriesRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<PostCategory> _dbSet;

        public PostCategoriesRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<PostCategory>();
        }

        public async Task CreatePostCategory(int postId, List<int> categoryIds)
        {
            foreach (var categoryId in categoryIds)
            {
                await _dbSet.AddAsync(new PostCategory
                {
                    PostId = postId,
                    CategoryId = categoryId
                });
            }

        }

        public void DeletePostCategories(List<PostCategory> postCategories)
        {
            foreach (var postCategory in postCategories)
            {
                _dbSet.Remove(postCategory);
            }
        }

        public async Task SaveChangesInPostCategories()
        {
            await _context.SaveChangesAsync();
        }
    }
}
