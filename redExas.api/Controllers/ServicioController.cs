using Application.DTOs.Emprendimiento;
using Application.DTOs.Portfolio;
using Application.DTOs.Servicio;
using Application.Interfaces.UseCases.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RedExas.api.Controllers
{
    public class ServicioController : Controller
    {
        private ICreateServicio _createServicio;
        public ServicioController(ICreateServicio createServicio)
        {
            _createServicio = createServicio;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> createServicio([FromBody] CreateServicioDTO createServicioDTO)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            ServicioDTO servicioDTO = await _createServicio.ExecuteAsync(createServicioDTO);
            return Ok(servicioDTO);
        }
    }
}
