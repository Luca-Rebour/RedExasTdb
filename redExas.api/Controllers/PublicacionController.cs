using Application.DTOs.Emprendimiento;
using Application.DTOs.Portfolio;
using Application.DTOs.Publicacion;
using Application.DTOs.Repuesta;
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
        private readonly IGetPublicaciones _getPublicaciones;
        private readonly IGetRespuestasDePublicacion _getRespuestasDePublicacion;

        public PublicacionController (
            ICreatePublicacion createPublicacion,
            IEditarPublicacion editarPublicacion,
            IEliminarPublicacion eliminarPublicacion,
            IGetPublicacionById getPublicacionById,
            IGetPublicaciones getPublicaciones,
            IGetRespuestasDePublicacion getRespuestasDePublicacion)
        {
            _createPublicacion = createPublicacion;
            _editarPublicacion = editarPublicacion;
            _eliminarPublicacion = eliminarPublicacion;
            _getPublicacionById = getPublicacionById;
            _getPublicaciones = getPublicaciones;
            _getRespuestasDePublicacion = getRespuestasDePublicacion;
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

        [HttpGet("respuestas/{publicacionId:guid}")]
        [Authorize]
        public async Task<IActionResult> getRespuestasDePublicacion([FromRoute] Guid publicacionId)
        {

            IEnumerable<RespuestaDTO> respuestas= await _getRespuestasDePublicacion.ExecuteAsync(publicacionId);
            return Ok(respuestas);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getPublicaciones([FromQuery] int? skip, [FromQuery] int? take)
        {
            int finalSkip = skip??= 0;
            int Finaltake = take??= 50;

            List<PublicacionDTO> publicacionesDTO = await _getPublicaciones.ExecuteAsync(finalSkip, Finaltake);
            return Ok(publicacionesDTO);
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
