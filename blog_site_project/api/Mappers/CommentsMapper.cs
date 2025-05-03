using api.DTOs.CommentDTOs;
using api.Models;

namespace api.Mappers
{
    public static class CommentsMapper
    {
        public static ListCommentDTO ToListCommentDTO(this Comment comment)
        {
            return new ListCommentDTO
            {
                CommentId = comment.CommentId,
                PostId = comment.PostId,
                CommentText = comment.CommentText,
                CreatedAt = comment.CreatedAt
            };
        }

        public static DetailsCommentDTO ToDetailsCommentDTO(this Comment comment)
        {
            return new DetailsCommentDTO
            {
                CommentId = comment.CommentId,
                PostId = comment.PostId,
                CommentText = comment.CommentText,
                CreatedAt = comment.CreatedAt
            };
        }

        public static Comment ToCommentFromCreateCommentDTO(this CreateCommentDTO createCommentDTO)
        {
            return new Comment
            {
                CommentText = createCommentDTO.CommentText
            };
        }

        public static ListCommentInDetailsPostDTO ToListCommentInDetailsPostDTO(this Comment comment)
        {
            return new ListCommentInDetailsPostDTO
            {
                CommentId = comment.CommentId,
                CommentText = comment.CommentText,
                CreatedAt = comment.CreatedAt
            };

        }
    }
}
