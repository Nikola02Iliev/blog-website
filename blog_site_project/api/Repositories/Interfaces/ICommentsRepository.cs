using api.DTOs.CommentDTOs;
using api.Models;

namespace api.Repositories.Interfaces
{
    public interface ICommentsRepository
    {
        Task<List<Comment>> GetComments(int page, int pageSize, string sortBy, string sortOrder, string filter);
        Task<Comment?> GetComment(int commentId);
        Task CreateComment(Comment comment);
        void UpdateComment(Comment comment, UpdateCommentDTO updateCommentDTO);
        void DeleteComment(Comment comment);
        Task<int> CountComments(string filter);
        Task SaveChangesInComments();
    }
}
