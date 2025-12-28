using Application.DTOs.AuthResult;
using Application.DTOs.Usuario;
using Application.Interfaces.UseCases.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedExas.api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly ISignIn _signIn;

        public AuthController(ISignIn signIn)
        {
            _signIn = signIn;
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] SignInDTO signInDTO)
        {
            SignInResultDTO result = await _signIn.ExecuteAsync(signInDTO);
            if (!result.Success)
            {
                return Unauthorized(new { message = result.Error });
            }

            return Ok(result);
        }


    }
}
