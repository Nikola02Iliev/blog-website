using api.DTOs.PostDTOs;
using api.Helpers;
using api.Models;

namespace api.Services.Interfaces
{
    public interface IPostsService
    {
        public Task<CustomPagedResult<ListPostDTO>> GetPagedPostsAsync(int page, int pageSize, string sortBy, string sortOrder, string filter);
        Task<Post?> GetPostAsync(int postId);
        Task CreatePostAsync(Post post, List<int> categoryIds);
        Task UpdatePostAsync(Post post, UpdatePostDTO updatePostDTO);
        Task DeletePostAsync(Post post);
    }
}
