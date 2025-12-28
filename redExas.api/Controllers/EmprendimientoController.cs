using Application.DTOs.Disponibilidad;
using Application.DTOs.Emprendimiento;
using Application.DTOs.ExAlumno;
using Application.DTOs.Portfolio;
using Application.DTOs.Servicio;
using Application.Interfaces.UseCases.Emprendimientos;
using Application.Interfaces.UseCases.Servicios;
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
        private readonly ICreateServicio _createServicio;
        private readonly IGetEmprendimientoById _getEmprendimientoById;
        private readonly IGetServicioById _getServicioById;

        public EmprendimientoController(
            ICreateEmprendimiento createEmprendimiento, 
            IGetAllEmprendimientos getAllEmprendimientos,
            ISearchEmprendimiento searchEmprendimiento,
            IGetServiciosDeEmprendimiento getServiciosDeEmprendimiento,
            ICreateServicio createServicio,
            IGetEmprendimientoById getEmprendimientoById,
            IGetServicioById getServicioById)
        {
            _createEmprendimiento = createEmprendimiento;
            _getAllEmprendimientos = getAllEmprendimientos;
            _searchEmprendimiento = searchEmprendimiento;
            _getServiciosDeEmprendimiento = getServiciosDeEmprendimiento;
            _createServicio = createServicio;
            _getEmprendimientoById = getEmprendimientoById;
            _getServicioById = getServicioById;
        }

        [HttpPost]
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

            return CreatedAtAction(nameof(getEmprendimientoById), new {EmprendimientoId = e.Id}, e);
        }

        [HttpGet("servicios")]
        public async Task<IActionResult> getAllServiciosDeEmprendimiento([FromQuery] Guid emprendimientoId)
        {
            List<ServicioDTO> s = await _getServiciosDeEmprendimiento.ExecuteAsync(emprendimientoId);
            return Ok(s);
        }

        [HttpGet]
        public async Task<IActionResult> searchEmprendimiento([FromQuery] SearchEmprendimientoQuery query)
        {
            var e = await _searchEmprendimiento.ExecuteAsync(query);
            return Ok(e);
        }

        [HttpPost("{emprendimientoId:guid}/servicios")]
        [Authorize]
        public async Task<IActionResult> createServicio([FromBody] CreateServicioDTO createServicioDTO, [FromRoute] Guid emprendimientoId)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            ServicioDTO servicioDTO = await _createServicio.ExecuteAsync(createServicioDTO, emprendimientoId);
            return CreatedAtAction(nameof(getServicioById), new { ServicioId = servicioDTO.Id }, servicioDTO);
        }

        [HttpGet("{emprendimientoId:guid}")]
        public async Task<IActionResult> getEmprendimientoById([FromRoute] Guid emprendimientoId)
        {
            EmprendimientoDTO emprendimientoDTO = await _getEmprendimientoById.ExecuteAsync(emprendimientoId);
            return Ok(emprendimientoDTO);
        }

        [HttpGet("{servicioId:guid}")]
        public async Task<IActionResult> getServicioById([FromRoute] Guid servicioId)
        {
            ServicioDTO servicioDTO = await _getServicioById.ExecuteAsync(servicioId);
            return Ok(servicioDTO);
        }
    }
}
