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
    public class PublicacionController : ControllerBase
    {
        private readonly ICreatePublicacion _createPublicacion;
        private readonly IEditarPublicacion _editarPublicacion;
        private readonly IEliminarPublicacion _eliminarPublicacion;
        private readonly IGetPublicacionById _getPublicacionById;

        public PublicacionController (
            ICreatePublicacion createPublicacion, 
            IEditarPublicacion editarPublicacion, 
            IEliminarPublicacion eliminarPublicacion, 
            IGetPublicacionById getPublicacionById)
        {
            _createPublicacion = createPublicacion;
            _editarPublicacion = editarPublicacion;
            _eliminarPublicacion = eliminarPublicacion;
            _getPublicacionById = getPublicacionById;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePublicacion([FromBody] CreatePublicacionDTO createPublicacionDTO)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            PublicacionDTO publicacionDTO = await _createPublicacion.ExecuteAsync(createPublicacionDTO, userId);

            return CreatedAtAction(nameof(getPublicacionById), new {publicacionId = publicacionDTO.Id}, publicacionDTO);
        }

        [HttpPut("{publicacionId:guid}")]
        [Authorize]
        public async Task<IActionResult> EditarPublicacion([FromBody] EditarPublicacionDTO createPublicacionDTO, [FromRoute] Guid publicacionId)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            PublicacionDTO publicacionDTO = await _editarPublicacion.ExecuteAsync(createPublicacionDTO, publicacionId, userId);

            return Ok(publicacionDTO);
        }

        [HttpGet("{publicacionId:guid}")]
        [Authorize]
        public async Task<IActionResult> getPublicacionById([FromRoute] Guid publicacionId)
        {

            PublicacionDTO publicacionDTO = await _getPublicacionById.ExecuteAsync(publicacionId);

            return Ok(publicacionDTO);
        }

        [HttpDelete("{publicacionId:guid}")]
        [Authorize]
        public async Task<IActionResult> EliminarPublicacion([FromRoute] Guid publicacionId)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            await _eliminarPublicacion.ExecuteAsync(publicacionId, userId);
            return NoContent();
        }
    }
}
