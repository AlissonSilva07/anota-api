using System.ComponentModel.DataAnnotations;

namespace Anota.Api.Models.Auth
{
    public record LoginRequest(
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        string Username,

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        string Password
    );
}
