using Application.DTOs.ExAlumnos;
using Application.Interfaces.UseCases.ExAlumnos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RedExas.api.Controllers
{
    [ApiController]
    [Route("api/ex-alumnos")]
    public class ExAlumnoController : ControllerBase
    {

        private readonly ICreateExAlumno _createExAlumno;

        public ExAlumnoController(ICreateExAlumno createExAlumno)
        {
            _createExAlumno = createExAlumno;
        }

        [HttpPost("create")]
        public async Task<IActionResult> createExAlumno([FromBody] CreateExAlumnoDTO createExAlumnoDTO)
        {
            await _createExAlumno.ExecuteAsync(createExAlumnoDTO);
            return Ok();
        }
    }
}
