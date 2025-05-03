using api.Context;
using api.DTOs.PostDTOs;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace api.Repositories.Implementations
{
    public class PostsRepository : IPostsRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Post> _dbSet;

        public PostsRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Post>();
        }

        public async Task<int> CountPosts(string filter)
        {
            IQueryable<Post> posts = _dbSet;
            if (!string.IsNullOrEmpty(filter))
            {
                posts = posts.Where(_ => _.Title.Contains(filter));
            }

            int postsCount = await posts.CountAsync();

            return postsCount;
        }

        public async Task CreatePost(Post post)
        {
            post.CreatedAt = DateTime.Now.ToUniversalTime();
            await _dbSet.AddAsync(post);
        }

        public void DeletePost(Post post)
        {
            _dbSet.Remove(post);
        }

        public async Task<Post?> GetPost(int postId)
        {
            var post = await _dbSet
            .Include(_ => _.Comments)
            .Include(_ => _.PostCategories)
                .ThenInclude(_ => _.Category)
            .FirstOrDefaultAsync(_ => _.PostId == postId);

            return post;
        }

        public async Task<List<Post>> GetPosts(int page, int pageSize, string sortBy, string sortOrder, string filter)
        {
            IQueryable<Post> posts = _dbSet
                .Include(_ => _.PostCategories)
                    .ThenInclude(_ => _.Category);

            if (!string.IsNullOrEmpty(filter))
            {
                posts = posts.Where(_ => _.Title.Contains(filter));
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                string sortExpression = $"{sortBy} {sortOrder}";
                posts = posts.OrderBy(sortExpression);
            }

            posts = posts.Skip((page - 1) * pageSize).Take(pageSize);

            var postsList = await posts.ToListAsync();

            return postsList;

        }

        public void UpdatePost(Post post, UpdatePostDTO updatePostDTO)
        {
            post.UpdatedAt = DateTime.Now.ToUniversalTime();
            post.Title = updatePostDTO.Title;
            post.Content = updatePostDTO.Content;
        }

        public async Task SaveChangesInPosts()
        {
            await _context.SaveChangesAsync();
        }
    }
}
