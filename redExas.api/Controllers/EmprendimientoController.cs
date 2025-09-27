using Application.DTOs.Emprendimiento;
using Application.DTOs.ExAlumnos;
using Application.UseCases.Emprendimientos;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RedExas.api.Controllers
{
    [ApiController]
    [Route("api/emprendimientos")]
    public class EmprendimientoController: ControllerBase
    {
        private readonly CreateEmprendimiento _createEmprendimiento;

        public EmprendimientoController(CreateEmprendimiento createEmprendimiento)
        {
            _createEmprendimiento = createEmprendimiento;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> createEmprendimiento([FromBody] CreateEmprendimientoDTO createEmprendimientoDTO)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            createEmprendimientoDTO.ExAlumnoId = userId;
            Emprendimiento e = await _createEmprendimiento.ExecuteAsync(createEmprendimientoDTO);
            return Ok(e);
        }
    }
}
