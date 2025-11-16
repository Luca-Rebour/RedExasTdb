using Application.DTOs.Emprendimiento;
using Application.DTOs.ExAlumnos;
using Application.Interfaces.UseCases.Emprendimientos;
using Application.Interfaces.UseCases.ExAlumnos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace RedExas.api.Controllers
{
    [ApiController]
    [Route("api/ex-alumnos")]
    public class ExAlumnoController : ControllerBase
    {

        private readonly ICreateExAlumno _createExAlumno;
        private readonly IGetEmprendimientosDeExAlumno _getEmprendimientosDeExAlumno;
        private readonly IGetAllExAlumnos _getAllExAlumnos;

        public ExAlumnoController(ICreateExAlumno createExAlumno, IGetEmprendimientosDeExAlumno getEmprendimientosDeExAlumno, IGetAllExAlumnos getAllExAlumnos)
        {
            _createExAlumno = createExAlumno;
            _getEmprendimientosDeExAlumno = getEmprendimientosDeExAlumno;
            _getAllExAlumnos = getAllExAlumnos;
        }

        [HttpPost("create")]
        public async Task<IActionResult> createExAlumno([FromBody] CreateExAlumnoDTO createExAlumnoDTO)
        {
            await _createExAlumno.ExecuteAsync(createExAlumnoDTO);
            return Ok();
        }

        [HttpGet("emprendimientos")]
        public async Task<IActionResult> getEmprendimientos([FromBody] Guid userId)
        {
            List<EmprendimientoDTO> e = await _getEmprendimientosDeExAlumno.ExecuteAsync(userId);
            return Ok(e);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAllExAlumnos()
        {
            List<ExAlumnoDTO> exAlumnos = await _getAllExAlumnos.ExecuteAsync();
            return Ok(exAlumnos);
        }
    }
}
