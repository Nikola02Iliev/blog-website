using api.DTOs.PostDTOs;
using api.Models;

namespace api.Mappers
{
    public static class PostsMapper
    {
        public static ListPostDTO ToListPostDTO(this Post post)
        {
            return new ListPostDTO
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                Categories = post.PostCategories.Select(_ => _.Category!.ToListCategoryDTOInListPostDTO()).ToList()
            };
        }

        public static DetailsPostDTO ToDetailsPostDTO(this Post post)
        {
            return new DetailsPostDTO
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                Comments = post.Comments.Select(_ => _.ToListCommentInDetailsPostDTO()).ToList(),
                Categories = post.PostCategories.Select(_ => _.Category!.ToListCategoryDTOInDetailsPostDTO()).ToList()
            };
        }

        public static Post ToPostFromCreatePostDTO(this CreatePostDTO createPostDTO)
        {
            return new Post
            {
                Title = createPostDTO.Title,
                Content = createPostDTO.Content
            };
        }
    }
}
