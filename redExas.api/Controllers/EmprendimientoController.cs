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
        private readonly ISearchEmprendimiento _searchEmprendimiento;

        public EmprendimientoController(ICreateEmprendimiento createEmprendimiento, IGetAllEmprendimientos getAllEmprendimientos, ISearchEmprendimiento searchEmprendimiento)
        {
            _createEmprendimiento = createEmprendimiento;
            _getAllEmprendimientos = getAllEmprendimientos;
            _searchEmprendimiento = searchEmprendimiento;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> createEmprendimiento([FromBody] CreateEmprendimientoDTO createEmprendimientoDTO)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            EmprendimientoDTO e = await _createEmprendimiento.ExecuteAsync(createEmprendimientoDTO, userId);
            return Ok(e);
        }

        [HttpGet("all")]
        public async Task<IActionResult> getAllEmprendimientos()
        {
            List<EmprendimientoDTO> e = await _getAllEmprendimientos.ExecuteAsync();
            return Ok(e);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchEmprendimiento([FromQuery] string query)
        {
            var e = await _searchEmprendimiento.ExecuteAsync(query);
            return Ok(e);
        }


    }
}
