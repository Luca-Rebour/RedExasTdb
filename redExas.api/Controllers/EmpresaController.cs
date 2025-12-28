using Application.DTOs.Emprendimiento;
using Application.DTOs.Empresa;
using Application.DTOs.ExAlumno;
using Application.Interfaces.UseCases.Empresas;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RedExas.api.Controllers
{
    [ApiController]
    [Route("api/empresas")]
    public class EmpresaController : ControllerBase
    {
        private readonly ICreateEmpresa _createEmpresa;
        private readonly IGetEmpresaById _getEmpresaById;

        public EmpresaController(
            ICreateEmpresa createEmpresa, 
            IGetEmpresaById getEmpresaById)
        {
            _createEmpresa = createEmpresa;
            _getEmpresaById = getEmpresaById;
        }

        [HttpPost]
        public async Task<IActionResult> createEmpresa([FromBody] CreateEmpresaDTO createEmpresaDTO)
        {
            EmpresaDTO empresaDTO = await _createEmpresa.ExecuteAsync(createEmpresaDTO);
            return CreatedAtAction(nameof(GetEmpresaById), new { EmpresaId = empresaDTO.Id}, empresaDTO);
        }

        [HttpGet("{empresaId:guid}")]
        public async Task<IActionResult> GetEmpresaById([FromRoute] Guid empresaId)
        {
            EmpresaDTO e = await _getEmpresaById.ExecuteAsync(empresaId);
            return Ok(e);
        }
    }
}
