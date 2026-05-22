using Anota.Api.Entities;
using Anota.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Anota.Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace Anota.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("Um usuário com este nome já existe.");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var token = await authService.LoginAsync(request);
            if (token is null)
            {
                return BadRequest("Usuário ou senha inválidos.");
            }

            return Ok(token);

        }

        [Authorize]
        [HttpGet]
        public IActionResult Authenticated()
        {
            return Ok("Você está autenticado(a)");
        }
    }
}
