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
    public class RespuestaController : Controller
    {
        private ICreateRespuesta _createRespuesta;

        public RespuestaController(ICreateRespuesta createRespuesta)
        {
            _createRespuesta = createRespuesta;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> createPublicacion([FromBody] CreateRespuestaDTO createRespuestaDTO)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            RespuestaDTO respuestaDTO = await _createRespuesta.ExecuteAsync(createRespuestaDTO, userId);

            return Ok(respuestaDTO);
        }
    }
}
