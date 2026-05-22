using Anota.Api.Entities;
using Anota.Api.Models.Auth;

namespace Anota.Api.Services.Auth
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(LoginRequest request);
        Task<LoginResponse?> LoginAsync(LoginRequest request);
        Task<LoginResponse?> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
