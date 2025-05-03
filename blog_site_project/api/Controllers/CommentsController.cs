using api.DTOs.CommentDTOs;
using api.Mappers;
using api.Responses.CommentResponses;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;
        private readonly IPostsService _postsService;

        public CommentsController(ICommentsService commentsService, IPostsService postsService)
        {
            _commentsService = commentsService;
            _postsService = postsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsAsync
        (
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "CommentId",
            [FromQuery] string sortOrder = "asc",
            [FromQuery] string filter = ""
        )
        {
            var comments = await _commentsService.GetPagedCommentsAsync(page, pageSize, sortBy, sortOrder, filter);
            return Ok(comments);
        }

        [HttpGet("get-comment/{commentId}/{postId}")]
        public async Task<IActionResult> GetCommentDetailsAsync(int commentId, int postId)
        {
            var existingPost = await _postsService.GetPostAsync(postId);

            var existingComment = await _commentsService.GetCommentAsync(commentId);

            if (existingPost == null || existingComment == null)
            {
                return NotFound("Comment not found");
            }

            var toDetailsCommentDTO = existingComment.ToDetailsCommentDTO();

            return Ok(toDetailsCommentDTO);
        }

        [HttpPost("create-comment/{postId}")]
        public async Task<IActionResult> CreateCommentAsync(CreateCommentDTO createCommentDTO, int postId)
        {
            var existingPost = await _postsService.GetPostAsync(postId);

            if (existingPost == null)
            {
                return NotFound("Post not found");
            }

            var createdComment = createCommentDTO.ToCommentFromCreateCommentDTO();

            await _commentsService.CreateCommentAsync(createdComment, postId);

            return Ok(new CreateCommentResponse
            {
                CommentId = createdComment.CommentId,
                PostId = postId,
                CommentText = createdComment.CommentText,
                CreatedAt = createdComment.CreatedAt
            });

        }

        [HttpPut("update-comment/{commentId}/{postId}")]
        public async Task<IActionResult> UpdateCommentAsync(int commentId, int postId, UpdateCommentDTO updateCommentDTO)
        {
            var existingPost = await _postsService.GetPostAsync(postId);

            var updatedComment = await _commentsService.GetCommentAsync(commentId);

            if (existingPost == null || updatedComment == null)
            {
                return NotFound("Comment not found");
            }

            await _commentsService.UpdateCommentAsync(updatedComment, updateCommentDTO);

            return Ok(new UpdateCommentResponse
            {
                CommentId = commentId,
                PostId = postId,
                CommentText = updatedComment.CommentText,
                UpdatedAt = updatedComment.UpdatedAt
            });

        }

        [HttpDelete("delete-comment/{commentId}/{postId}")]
        public async Task<IActionResult> DeleteCommentAsync(int commentId, int postId)
        {
            var existingPost = await _postsService.GetPostAsync(postId);

            var deletedComment = await _commentsService.GetCommentAsync(commentId);

            if (existingPost == null || deletedComment == null)
            {
                return NotFound("Comment not found");
            }

            await _commentsService.DeleteCommentAsync(deletedComment);

            return Ok("Comment deleted");

        }


    }
}
