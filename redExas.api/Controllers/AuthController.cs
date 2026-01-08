using Application.DTOs.AuthResult;
using Application.DTOs.Usuario;
using Application.Interfaces.UseCases.Auth;
using Application.Interfaces.UseCases.Usuario;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace RedExas.api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ISignIn _signIn;
        private readonly IMe _me;

        public AuthController(ISignIn signIn, ILogger<AuthController> logger, IMe me)
        {
            _signIn = signIn;
            _logger = logger;
            _me = me;
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] SignInDTO signInDTO)
        {
            var swTotal = Stopwatch.StartNew();
            SignInResultDTO result = await _signIn.ExecuteAsync(signInDTO);
            if (!result.Success)
            {
                return Unauthorized(new { message = result.Error });
            }
            swTotal.Stop();
            _logger.LogInformation("LOGIN TOTAL: {ms} ms", swTotal.ElapsedMilliseconds);
            return Ok(result);
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> me()
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            UsuarioDTO usuario = await _me.ExecuteAsync(userId);
            return Ok(usuario);
        }


    }
}
