using api.DTOs.CommentDTOs;
using api.Helpers;
using api.Mappers;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services.Implementations
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public async Task CreateCommentAsync(Comment comment, int postId)
        {
            comment.PostId = postId;
            await _commentsRepository.CreateComment(comment);
            await _commentsRepository.SaveChangesInComments();
        }

        public async Task DeleteCommentAsync(Comment comment)
        {
            _commentsRepository.DeleteComment(comment);
            await _commentsRepository.SaveChangesInComments();
        }

        public async Task<Comment?> GetCommentAsync(int commentId)
        {
            var comment = await _commentsRepository.GetComment(commentId);

            return comment;
        }

        public async Task<CustomPagedResult<ListCommentDTO>> GetPagedCommentsAsync(int page, int pageSize, string sortBy, string sortOrder, string filter)
        {
            var comments = await _commentsRepository.GetComments(page, pageSize, sortBy, sortOrder, filter);


            var toListCommentDTOs = comments.Select(_ => _.ToListCommentDTO()).ToList();


            var totalComments = await _commentsRepository.CountComments(filter);

            var pagedComments = new CustomPagedResult<ListCommentDTO>
            {
                Data = toListCommentDTOs,
                TotalCount = totalComments,
                Page = page,
                PageSize = pageSize

            };

            return pagedComments;

        }

        public async Task UpdateCommentAsync(Comment comment, UpdateCommentDTO updateCommentDTO)
        {
            _commentsRepository.UpdateComment(comment, updateCommentDTO);
            await _commentsRepository.SaveChangesInComments();
        }
    }
}
