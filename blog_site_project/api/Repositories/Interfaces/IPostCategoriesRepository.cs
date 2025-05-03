using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IPostCategoriesRepository
    {
        Task CreatePostCategory(int postId, List<int> categoryIds);
        void DeletePostCategories(List<PostCategory> postCategories);
        Task SaveChangesInPostCategories();
    }
}
