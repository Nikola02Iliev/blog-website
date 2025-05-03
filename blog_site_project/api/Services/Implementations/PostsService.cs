using api.DTOs.PostDTOs;
using api.Helpers;
using api.Mappers;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services.Implementations
{
    public class PostsService : IPostsService
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IPostCategoriesRepository _postCategoriesRepository;

        public PostsService(IPostsRepository postsRepository, IPostCategoriesRepository postCategoriesRepository)
        {
            _postsRepository = postsRepository;
            _postCategoriesRepository = postCategoriesRepository;
        }

        public async Task CreatePostAsync(Post post, List<int> categoryIds)
        {

            // Create and persist the post first
            await _postsRepository.CreatePost(post);
            await _postsRepository.SaveChangesInPosts();

            // Then create relationships with categories
            await _postCategoriesRepository.CreatePostCategory(post.PostId, categoryIds);
            await _postCategoriesRepository.SaveChangesInPostCategories();

        }

        public async Task DeletePostAsync(Post post)
        {
            _postsRepository.DeletePost(post);
            await _postsRepository.SaveChangesInPosts();
        }

        public async Task<CustomPagedResult<ListPostDTO>> GetPagedPostsAsync(int page, int pageSize, string sortBy, string sortOrder, string filter)
        {
            var posts = await _postsRepository.GetPosts(page, pageSize, sortBy, sortOrder, filter);

            var toListPostDTOs = posts.Select(_ => _.ToListPostDTO()).ToList();

            var totalPosts = await _postsRepository.CountPosts(filter);

            var pagedPosts = new CustomPagedResult<ListPostDTO>
            {
                Data = toListPostDTOs,
                TotalCount = totalPosts,
                Page = page,
                PageSize = pageSize
            };

            return pagedPosts;
        }

        public async Task<Post?> GetPostAsync(int postId)
        {
            var post = await _postsRepository.GetPost(postId);

            return post;
        }

        public async Task UpdatePostAsync(Post post, UpdatePostDTO updatePostDTO)
        {
            _postCategoriesRepository.DeletePostCategories(post.PostCategories);
            await _postCategoriesRepository.SaveChangesInPostCategories();

            _postsRepository.UpdatePost(post, updatePostDTO);
            await _postsRepository.SaveChangesInPosts();

            await _postCategoriesRepository.CreatePostCategory(post.PostId, updatePostDTO.CategoryIds);
            await _postCategoriesRepository.SaveChangesInPostCategories();
        }
    }
}
