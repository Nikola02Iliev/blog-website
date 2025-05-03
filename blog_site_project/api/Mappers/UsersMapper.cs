using api.DTOs.UserDTOs;
using api.Models;

namespace api.Mappers
{
    public static class UsersMapper
    {
        public static ListUserDTO ToListUserDTO(this AppUser user)
        {
            return new ListUserDTO
            {
                Username = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public static DetailsUserDTO ToDetailsUserDTO(this AppUser user)
        {
            return new DetailsUserDTO
            {
                Username = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
    }
}
