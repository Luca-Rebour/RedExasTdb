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
        private readonly IEditarPublicacion _editarPublicacion;
        private readonly IEliminarPublicacion _eliminarPublicacion;

        public PublicacionController (ICreatePublicacion createPublicacion, IEditarPublicacion editarPublicacion, IEliminarPublicacion eliminarPublicacion)
        {
            _createPublicacion = createPublicacion;
            _editarPublicacion = editarPublicacion;
            _eliminarPublicacion = eliminarPublicacion;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreatePublicacion([FromBody] CreatePublicacionDTO createPublicacionDTO)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            PublicacionDTO publicacionDTO = await _createPublicacion.ExecuteAsync(createPublicacionDTO, userId);

            return Ok(publicacionDTO);
        }

        [HttpPut("editar/{publicacionId:Guid}")]
        [Authorize]
        public async Task<IActionResult> EditarPublicacion([FromBody] EditarPublicacionDTO createPublicacionDTO, [FromRoute] Guid publicacionId)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            PublicacionDTO publicacionDTO = await _editarPublicacion.ExecuteAsync(createPublicacionDTO, publicacionId, userId);

            return Ok(publicacionDTO);
        }

        [HttpDelete("eliminar/{publicacionId:Guid}")]
        [Authorize]
        public async Task<IActionResult> EliminarPublicacion([FromRoute] Guid publicacionId)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            await _eliminarPublicacion.ExecuteAsync(publicacionId, userId);
            return Ok();
        }
    }
}
