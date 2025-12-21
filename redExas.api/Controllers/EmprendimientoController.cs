using Application.DTOs.Disponibilidad;
using Application.DTOs.Emprendimiento;
using Application.DTOs.ExAlumnos;
using Application.DTOs.Portfolio;
using Application.DTOs.Servicio;
using Application.Interfaces.UseCases.Emprendimientos;
using Application.UseCases.Emprendimientos;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace RedExas.api.Controllers
{
    [ApiController]
    [Route("api/emprendimientos")]
    public class EmprendimientoController: ControllerBase
    {
        private readonly ICreateEmprendimiento _createEmprendimiento;
        private readonly IGetAllEmprendimientos _getAllEmprendimientos;
        private readonly ISearchEmprendimiento _searchEmprendimiento;
        private readonly IGetServiciosDeEmprendimiento _getServiciosDeEmprendimiento;

        public EmprendimientoController(ICreateEmprendimiento createEmprendimiento, IGetAllEmprendimientos getAllEmprendimientos, ISearchEmprendimiento searchEmprendimiento, IGetServiciosDeEmprendimiento getServiciosDeEmprendimiento)
        {
            _createEmprendimiento = createEmprendimiento;
            _getAllEmprendimientos = getAllEmprendimientos;
            _searchEmprendimiento = searchEmprendimiento;
            _getServiciosDeEmprendimiento = getServiciosDeEmprendimiento;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> createEmprendimiento([FromForm] CreateEmprendimientoDTO request)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            string imagenPath = string.Empty;
            
            

            if (request.Logo is not null && request.Logo.Length > 0)
            {
                var uploadsFolder = Path.Combine("wwwroot", "Uploads", "Emprendimientos", "Logos");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.Logo.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Logo.CopyToAsync(stream);
                }

                request.LogoUrl = $"/Uploads/Emprendimientos/Logos/{fileName}";
            };

            if (request.PortfoliosDTO != null)
            {
                foreach (CreatePortfolioDTO p in request.PortfoliosDTO)
                {
                    if (p.Imagen is null || p.Imagen.Length == 0)
                        continue;

                    var uploadsFolder = Path.Combine("wwwroot", "Uploads", "Portfolios", "Images");
                    Directory.CreateDirectory(uploadsFolder);

                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(p.Imagen.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    await p.Imagen.CopyToAsync(stream);

                    p.ImagenUrl = $"/Uploads/Portfolios/Images/{fileName}";
                }
            }
            


            EmprendimientoDTO e = await _createEmprendimiento.ExecuteAsync(request, userId);

            return Ok(e);
        }


        [HttpGet("all")]
        public async Task<IActionResult> getAllEmprendimientos()
        {
            List<EmprendimientoDTO> e = await _getAllEmprendimientos.ExecuteAsync();
            return Ok(e);
        }

        [HttpGet("servicios")]
        public async Task<IActionResult> getAllEmprendimientos([FromQuery] Guid emprendimientoId)
        {
            List<ServicioDTO> s = await _getServiciosDeEmprendimiento.ExecuteAsync(emprendimientoId);
            return Ok(s);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchEmprendimiento([FromQuery] string? query, [FromQuery] Guid? estudioId)
        {
            var e = await _searchEmprendimiento.ExecuteAsync(query, estudioId);
            return Ok(e);
        }


    }
}
