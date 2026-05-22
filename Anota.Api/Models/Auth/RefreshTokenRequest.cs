using System.ComponentModel.DataAnnotations;

namespace Anota.Api.Models.Auth
{
    public record RefreshTokenRequest(
        [Required(ErrorMessage = "User ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "User ID must be a valid positive integer.")]
        int UserId,

        [Required(ErrorMessage = "Refresh token is required.")]
        string RefreshToken
    );
}
