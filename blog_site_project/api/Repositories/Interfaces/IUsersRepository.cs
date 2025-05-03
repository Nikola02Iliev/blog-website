using api.DTOs.UserDTOs;
using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<AppUser>> GetUsers(int page, int pageSize, string sortBy, string sortOrder, string filter);
        Task<AppUser?> GetUserByUsername(string username);
        void UpdateUser(AppUser user, UpdateUserDTO updateUserDTO);
        Task DeleteUser(AppUser user);
        Task<int> CountUsers(string filter);
        Task SaveChangesInUsers();

    }
}
