using api.DTOs.UserDTOs;
using api.Helpers;
using api.Mappers;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System.Linq.Dynamic.Core;

namespace api.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task DeleteUserAsync(AppUser user)
        {
            await _usersRepository.DeleteUser(user);
        }

        public async Task<CustomPagedResult<ListUserDTO>> GetPagedUsersAsync(int page, int pageSize, string sortBy, string sortOrder, string filter)
        {
            var users = await _usersRepository.GetUsers(page, pageSize, sortBy, sortOrder, filter);
            var totalUsers = await _usersRepository.CountUsers(filter);
            var toListUserDTOs = users.Select(_ => _.ToListUserDTO()).ToList();

            var pagedUsers = new CustomPagedResult<ListUserDTO>
            {
                Data = toListUserDTOs,
                TotalCount = totalUsers,
                Page = page,
                PageSize = pageSize
            };

            return pagedUsers;
        }

        public async Task<AppUser?> GetUserByUsernameAsync(string username)
        {
            var user = await _usersRepository.GetUserByUsername(username);
            
            return user;
        }

        public async Task UpdateUserAsync(AppUser user, UpdateUserDTO updateUserDTO)
        {
            _usersRepository.UpdateUser(user, updateUserDTO);
            await _usersRepository.SaveChangesInUsers();
        }
    }
}
