using Application.DTOs.Emprendimiento;
using Application.DTOs.Empresa;
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

        public EmpresaController(ICreateEmpresa createEmpresa)
        {
            _createEmpresa = createEmpresa;
        }

        [HttpPost("create")]
        public async Task<IActionResult> createEmpresa([FromBody] CreateEmpresaDTO createEmpresaDTO)
        {
            EmpresaDTO empresaDTO = await _createEmpresa.ExecuteAsync(createEmpresaDTO);
            return Ok(empresaDTO);
        }
    }
}
