using api.Context;
using api.DTOs.CommentDTOs;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace api.Repositories.Implementations
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Comment> _dbSet;

        public CommentsRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Comment>();
        }

        public async Task<int> CountComments(string filter)
        {
            IQueryable<Comment> comments = _dbSet;

            if (!string.IsNullOrEmpty(filter))
            {
                comments = comments.Where(_ => _.CommentText.Contains(filter));
            }

            var commentsCount = await comments.CountAsync();

            return commentsCount;

        }

        public async Task CreateComment(Comment comment)
        {
            comment.CreatedAt = DateTime.Now.ToUniversalTime();
            await _dbSet.AddAsync(comment);
        }

        public void DeleteComment(Comment comment)
        {
            _dbSet.Remove(comment);
        }

        public async Task<Comment?> GetComment(int commentId)
        {
            var comment = await _dbSet.FirstOrDefaultAsync(_ => _.CommentId == commentId);

            return comment;
        }

        public async Task<List<Comment>> GetComments(int page, int pageSize, string sortBy, string sortOrder, string filter)
        {
            IQueryable<Comment> comments = _dbSet;

            if (!string.IsNullOrEmpty(filter))
            {
                comments = comments.Where(_ => _.CommentText.Contains(filter));
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                string sortExpression = $"{sortBy} {sortOrder}";
                comments.OrderBy(sortExpression);
            }

            comments = comments.Skip((page - 1) * pageSize).Take(pageSize);

            var commentsToList = await comments.ToListAsync();

            return commentsToList;
        }

        public void UpdateComment(Comment comment, UpdateCommentDTO updateCommentDTO)
        {
            comment.UpdatedAt = DateTime.Now.ToUniversalTime();
            comment.CommentText = updateCommentDTO.CommentText;
        }

        public async Task SaveChangesInComments()
        {
            await _context.SaveChangesAsync();
        }

    }
}
