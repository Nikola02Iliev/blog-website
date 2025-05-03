using api.Models;

namespace api.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser user);


    }
}
