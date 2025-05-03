using api.DTOs.UserDTOs;
using api.Helpers;
using api.Models;
using System.Linq.Dynamic.Core;

namespace api.Services.Interfaces
{
    public interface IUsersService
    {
        Task<CustomPagedResult<ListUserDTO>> GetPagedUsersAsync(int page, int pageSize, string sortBy, string sortOrder, string filter);
        Task<AppUser?> GetUserByUsernameAsync(string username);
        Task DeleteUserAsync(AppUser user);
        Task UpdateUserAsync(AppUser user, UpdateUserDTO updateUserDTO);

    }
}
