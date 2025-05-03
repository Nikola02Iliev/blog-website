using api.DTOs.CommentDTOs;
using api.Helpers;
using api.Models;

namespace api.Services.Interfaces
{
    public interface ICommentsService
    {
        Task<CustomPagedResult<ListCommentDTO>> GetPagedCommentsAsync(int page, int pageSize, string sortBy, string sortOrder, string filter);
        Task<Comment?> GetCommentAsync(int commentId);
        Task CreateCommentAsync(Comment comment, int postId);
        Task UpdateCommentAsync(Comment comment, UpdateCommentDTO updateCommentDTO);
        Task DeleteCommentAsync(Comment comment);
    }
}
