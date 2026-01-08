using Application.DTOs.Estudio;
using Application.DTOs.ExAlumno;
using Application.Interfaces.UseCases.Estudios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedExas.api.Controllers
{
    [ApiController]
    [Route("api/estudios")]
    public class EstudioController : ControllerBase
    {
        private IGetAllEstudios _getAllEstudios;
        public EstudioController(IGetAllEstudios getAllEstudios) { 
        
            _getAllEstudios = getAllEstudios;
        }

        [HttpGet]
        public async Task<IActionResult> getEstudios()
        {
            List<EstudioDTO> e = await _getAllEstudios.ExecuteAsync();
            return Ok(e);
        }
    }
}
