using api.DTOs.PostDTOs;
using api.Mappers;
using api.Responses.PostResponses;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;
        private readonly ICategoriesService _categoriesService;

        public PostsController(IPostsService postsService, ICategoriesService categoriesService)
        {
            _postsService = postsService;
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostsAsync
        (
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "PostId",
            [FromQuery] string sortOrder = "asc",
            [FromQuery] string filter = ""
        )
        {
            var posts = await _postsService.GetPagedPostsAsync(page, pageSize, sortBy, sortOrder, filter);
            return Ok(posts);
        }

        [HttpGet("get-post/{postId}")]
        public async Task<IActionResult> GetPostDetailsAsync(int postId)
        {
            var existingPost = await _postsService.GetPostAsync(postId);

            if (existingPost == null)
            {
                return NotFound("Post not found");
            }

            var toDetailsPostDTO = existingPost.ToDetailsPostDTO();

            return Ok(toDetailsPostDTO);
        }

        [HttpPost("create-post")]
        public async Task<IActionResult> CreatePostAsync(CreatePostDTO createPostDTO)
        {
            var (boolValue, numberValue) = await _categoriesService.CategoriesExists(createPostDTO.CategoryIds);

            if (!boolValue)
            {
                return BadRequest($"No category exists with Id {numberValue}");
            }

            var createdPost = createPostDTO.ToPostFromCreatePostDTO();

            await _postsService.CreatePostAsync(createdPost, createPostDTO.CategoryIds);

            return Ok(new CreatePostResponse
            {
                PostId = createdPost.PostId,
                Title = createdPost.Title,
                Content = createdPost.Content,
                CreatedAt = createdPost.CreatedAt
            });

        }

        [HttpPut("update-post/{postId}")]
        public async Task<IActionResult> UpdatePostAsync(int postId, UpdatePostDTO updatePostDTO)
        {
            var (boolValue, numberValue) = await _categoriesService.CategoriesExists(updatePostDTO.CategoryIds);

            if (!boolValue)
            {
                return BadRequest($"No category exists with Id {numberValue}");
            }

            var updatedPost = await _postsService.GetPostAsync(postId);

            if (updatedPost == null)
            {
                return NotFound("Post not found");
            }

            await _postsService.UpdatePostAsync(updatedPost, updatePostDTO);

            return Ok(new UpdatePostResponse
            {
                PostId = postId,
                Title = updatedPost.Title,
                Content = updatedPost.Content,
                UpdatedAt = updatedPost.UpdatedAt
            });

        }

        [HttpDelete("delete-post/{postId}")]
        public async Task<IActionResult> DeletePostAsync(int postId)
        {
            var deletedPost = await _postsService.GetPostAsync(postId);

            if (deletedPost == null)
            {
                return NotFound("Post not found");
            }

            await _postsService.DeletePostAsync(deletedPost);

            return Ok("Post deleted");
        }


    }
}
