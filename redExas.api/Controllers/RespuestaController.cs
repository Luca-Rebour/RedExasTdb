using Application.DTOs.Publicacion;
using Application.DTOs.Repuesta;
using Application.Interfaces.UseCases.Respuestas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RedExas.api.Controllers
{
    [ApiController]
    [Route("api/respuestas")]
    public class RespuestaController : ControllerBase
    {
        private ICreateRespuesta _createRespuesta;
        private IDeleteRespuesta _deleteRespuesta;
        private IGetRespuestaById _getRespuestaById;
        public RespuestaController(
            ICreateRespuesta createRespuesta, 
            IDeleteRespuesta deleteRespuesta, 
            IGetRespuestaById getRespuestaById)
        {
            _createRespuesta = createRespuesta;
            _deleteRespuesta = deleteRespuesta;
            _getRespuestaById = getRespuestaById;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> createRespuesta([FromBody] CreateRespuestaDTO createRespuestaDTO)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            RespuestaDTO respuestaDTO = await _createRespuesta.ExecuteAsync(createRespuestaDTO, userId);

            return CreatedAtAction(nameof(GetRespuestaById), new { RespuestaId = respuestaDTO.Id}, respuestaDTO);
        }


        [HttpGet("{respuestaId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetRespuestaById([FromRoute] Guid respuestaId)
        {
            RespuestaDTO respuestaDTO = await _getRespuestaById.ExecuteAsync(respuestaId);

            return Ok(respuestaDTO);
        }

        [HttpDelete("delete/{respuestaId:guid}")]
        [Authorize]
        public async Task<IActionResult> createRespuesta([FromRoute] Guid respuestaId)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            await _deleteRespuesta.ExecuteAsync(respuestaId, userId);
            return NoContent();
        }
    }
}
