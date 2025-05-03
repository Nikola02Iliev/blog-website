using api.DTOs.PostDTOs;
using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IPostsRepository
    {
        Task<List<Post>> GetPosts(int page, int pageSize, string sortBy, string sortOrder, string filter);
        Task<Post?> GetPost(int postId);
        Task CreatePost(Post post);
        void UpdatePost(Post post, UpdatePostDTO updatePostDTO);
        void DeletePost(Post post);
        Task<int> CountPosts(string filter);
        Task SaveChangesInPosts();

    }
}
