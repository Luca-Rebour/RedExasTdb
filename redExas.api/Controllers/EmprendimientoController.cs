using Application.DTOs.Emprendimiento;
using Application.DTOs.ExAlumnos;
using Application.Interfaces.UseCases.Emprendimientos;
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
        private readonly ICreateEmprendimiento _createEmprendimiento;
        private readonly IGetAllEmprendimientos _getAllEmprendimientos;

        public EmprendimientoController(ICreateEmprendimiento createEmprendimiento, IGetAllEmprendimientos getAllEmprendimientos)
        {
            _createEmprendimiento = createEmprendimiento;
            _getAllEmprendimientos = getAllEmprendimientos;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> createEmprendimiento([FromBody] CreateEmprendimientoDTO createEmprendimientoDTO)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            Emprendimiento e = await _createEmprendimiento.ExecuteAsync(createEmprendimientoDTO, userId);
            return Ok(e);
        }

        [HttpGet("all")]
        public async Task<IActionResult> getAllEmprendimientos()
        {
            List<EmprendimientoDTO> e = await _getAllEmprendimientos.ExecuteAsync();
            return Ok(e);
        }
    }
}
