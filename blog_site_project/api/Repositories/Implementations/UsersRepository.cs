using api.Context;
using api.DTOs.UserDTOs;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace api.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public UsersRepository(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<int> CountUsers(string filter)
        {
            IQueryable<AppUser> users = _userManager.Users;

            if(!string.IsNullOrEmpty(filter))
            {
                users = users.Where(_ => _.UserName.Contains(filter));
            }

            var usersCount = await users.CountAsync();
            
            return usersCount;
        }

        public async Task DeleteUser(AppUser user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task<AppUser?> GetUserByUsername(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return user;
        }

        public async Task<List<AppUser>> GetUsers(int page, int pageSize, string sortBy, string sortOrder, string filter)
        {
            IQueryable<AppUser> users = _userManager.Users;

            if (!string.IsNullOrEmpty(filter))
            {
                users = users.Where(_ => _.UserName.Contains(filter));
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                string sortExpression = $"{sortBy} {sortOrder}";
                users = users.OrderBy(sortExpression);
            }

            users = users.Skip((page - 1) * pageSize).Take(pageSize);

            var usersList = await users.ToListAsync();

            return usersList;
        }

        public void UpdateUser(AppUser user, UpdateUserDTO updateUserDTO)
        {
            user.UpdatedAt = DateTime.Now.ToUniversalTime();
            user.UserName = updateUserDTO.Username;
            user.Email = updateUserDTO.Email;
            user.NormalizedUserName = updateUserDTO.Username.ToUpper();
            user.NormalizedEmail = updateUserDTO.Email.ToUpper();
        }

        public async Task SaveChangesInUsers()
        {
            await _context.SaveChangesAsync();
        }
    }
}
