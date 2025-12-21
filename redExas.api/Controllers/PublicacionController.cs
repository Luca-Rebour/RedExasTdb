using Application.DTOs.Emprendimiento;
using Application.DTOs.Portfolio;
using Application.DTOs.Publicacion;
using Application.Interfaces.UseCases.Publicaciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RedExas.api.Controllers
{
    [ApiController]
    [Route("api/publicaciones")]
    public class PublicacionController : Controller
    {
        private readonly ICreatePublicacion _createPublicacion;

        public PublicacionController (ICreatePublicacion createPublicacion)
        {
            _createPublicacion = createPublicacion;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> createPublicacion([FromBody] CreatePublicacionDTO createPublicacionDTO)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            PublicacionDTO publicacionDTO = await _createPublicacion.ExecuteAsync(createPublicacionDTO, userId);

            return Ok(publicacionDTO);
        }
    }
}
