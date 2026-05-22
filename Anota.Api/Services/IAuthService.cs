using Anota.Api.Entities;
using Anota.Api.Models;

namespace Anota.Api.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<LoginResponse?> LoginAsync(UserDto request);
        Task<LoginResponse?> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
