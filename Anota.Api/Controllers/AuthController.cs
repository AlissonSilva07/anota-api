using Anota.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Anota.Api.Services.Auth;
using Anota.Api.Models.Auth;

namespace Anota.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(LoginRequest request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("Um usuário com este nome já existe.");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var result = await authService.LoginAsync(request);
            if (result is null)
            {
                return BadRequest("Usuário ou senha inválidos.");
            }

            return Ok(result);

        }


        [HttpPost("refresh-token")]
        public async Task<ActionResult<LoginResponse>> RefreshToken(RefreshTokenRequest request)
        {
            var result = await authService.RefreshTokenAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
            {
                return BadRequest("Token de atualização inválido.");
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet] 
        public IActionResult Authenticated()
        {
            return Ok("Você está autenticado(a)");
        }
    }
}
