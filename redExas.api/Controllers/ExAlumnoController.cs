using Application.DTOs.Emprendimiento;
using Application.DTOs.ExAlumno;
using Application.DTOs.ExAlumno;
using Application.DTOs.Servicio;
using Application.Interfaces.UseCases.Emprendimientos;
using Application.Interfaces.UseCases.ExAlumnos;
using Application.Interfaces.UseCases.Servicios;
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
        private readonly IGetExAlumnoById _getExAlumnoById;
        private readonly IGetServiciosDeExAlumno _getServiciosDeExAlumno;

        public ExAlumnoController(
            ICreateExAlumno createExAlumno, 
            IGetEmprendimientosDeExAlumno getEmprendimientosDeExAlumno, 
            IGetAllExAlumnos getAllExAlumnos,
            IGetExAlumnoById getExAlumnoById,
            IGetServiciosDeExAlumno getServiciosDeExAlumno)
        {
            _createExAlumno = createExAlumno;
            _getEmprendimientosDeExAlumno = getEmprendimientosDeExAlumno;
            _getAllExAlumnos = getAllExAlumnos;
            _getExAlumnoById = getExAlumnoById;
            _getServiciosDeExAlumno = getServiciosDeExAlumno;
        }

        [HttpPost]
        public async Task<IActionResult> createExAlumno([FromBody] CreateExAlumnoDTO createExAlumnoDTO)
        {
            ExAlumnoDTO exAlumnoDTO = await _createExAlumno.ExecuteAsync(createExAlumnoDTO);
            return CreatedAtAction(nameof(getExAlumnoById), new { ExAlumnoId = exAlumnoDTO.Id }, exAlumnoDTO) ;
        }

        [HttpGet("emprendimientos/{exAlumnoId:guid}")]
        public async Task<IActionResult> getEmprendimientos([FromRoute] Guid exAlumnoId)
        {
            List<EmprendimientoDTO> e = await _getEmprendimientosDeExAlumno.ExecuteAsync(exAlumnoId);
            return Ok(e);
        }

        [HttpGet("servicios/{exAlumnoId:guid}")]
        public async Task<IActionResult> getServicios([FromRoute] Guid exAlumnoId)
        {
            IEnumerable<ServicioDTO> serviciosDTOs = await _getServiciosDeExAlumno.ExecuteAsync(exAlumnoId);
            return Ok(serviciosDTOs);
        }

        [HttpGet("{exAlumnoId:guid}")]
        public async Task<IActionResult> getExAlumnoById([FromRoute] Guid exAlumnoId)
        {
            ExAlumnoDetailDTO e = await _getExAlumnoById.ExecuteAsync(exAlumnoId);
            return Ok(e);
        }

        [HttpGet]
        public async Task<IActionResult> getAllExAlumnos()
        {
            List<ExAlumnoDTO> exAlumnos = await _getAllExAlumnos.ExecuteAsync();
            return Ok(exAlumnos);
        }
    }
}
