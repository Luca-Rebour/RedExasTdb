using Application.DTOs.Direccion;
using Application.DTOs.Emprendimiento;
using Application.DTOs.Estudio;
using Application.DTOs.ExAlumno;
using Application.DTOs.Portfolio;
using Application.DTOs.Servicio;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmprendimientoRepository : IEmprendimientoRepository
    {
        private readonly AppDbContext _context;

        public EmprendimientoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateEmprendimiento(Emprendimiento emprendimiento)
        {
            _context.Emprendimientos.Add(emprendimiento);
        }

        public async Task<List<Emprendimiento>> GetAllEmprendimientosAsync()
        {
            return await _context.Emprendimientos
                        .AsNoTracking()
                        .Include(e => e.ExAlumno)
                        .Include(d => d.Direccion)
                        .Include(s => s.Servicios)
                        .Include(e => e.Estudio)
                        .Include(e => e.Disponibilidad)
                            .ThenInclude(d => d.Dias).ToListAsync();
        }

        public async Task<Emprendimiento> GetEmprendimientoById(Guid emprendimientoId)
        {
            return await _context.Emprendimientos
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Id.Equals(emprendimientoId));
        }

        public async Task<List<Emprendimiento>> GetEmprendimientosDeExAlumnoAsync(Guid userId)
        {
            return await _context.Emprendimientos
                        .AsNoTracking()
                        .Include(e => e.Direccion)
                        .Include(e => e.Disponibilidad)
                            .ThenInclude(d => d.Dias)
                        .Include(e => e.Portfolios)
                        .Include(e => e.Estudio)
                        .Include(e => e.Servicios)
                        .Include(e => e.ExAlumno)
                        .Where(e => e.ExAlumnoId
                        .Equals(userId))
                        .ToListAsync();
        }

        public async Task<List<Servicio>> GetServiciosDeEmprendimiento(Guid emprendimientoId)
        {
            return await _context.Servicios
                        .AsNoTracking()
                        .Include(s => s.Emprendimiento)
                        .Where(s => s.EmprendimientoId
                        .Equals(emprendimientoId))
                        .ToListAsync();
        }

        public async Task<List<EmprendimientoDTO>> SearchEmprendimientoAsync(SearchEmprendimientoQuery q)
        {
            // Base query
            IQueryable<Emprendimiento> query = _context.Emprendimientos
                .AsNoTracking()
                .Include(e => e.Estudio)
                .Include(e => e.Direccion)
                .Include(e => e.Servicios)
                .Include(e => e.Disponibilidad)
                .Include(e => e.Portfolios)
                .Include(e => e.ExAlumno)
                    .ThenInclude(ex => ex.Estudios);

            // Filters (AND)
            if (!string.IsNullOrWhiteSpace(q.Departamento))
            {
                var dep = q.Departamento.Trim();
                query = query.Where(e =>
                    EF.Functions.ILike(e.Direccion.Departamento, $"%{dep}%"));
            }

            if (!string.IsNullOrWhiteSpace(q.Calle))
            {
                var calle = q.Calle.Trim();
                query = query.Where(e =>
                    EF.Functions.ILike(e.Direccion.Calle, $"%{calle}%"));
            }

            if (q.ExAlumnoId.HasValue)
            {
                var exId = q.ExAlumnoId.Value;
                query = query.Where(e => e.ExAlumnoId == exId);
            }

            if (!string.IsNullOrWhiteSpace(q.NombreDelEmprendimiento))
            {
                var name = q.NombreDelEmprendimiento.Trim();
                query = query.Where(e =>
                    EF.Functions.ILike(e.Nombre, $"%{name}%"));
            }

            if (!string.IsNullOrWhiteSpace(q.NombreDelServicio))
            {
                var service = q.NombreDelServicio.Trim();
                query = query.Where(e =>
                    e.Servicios.Any(s => EF.Functions.ILike(s.Nombre, $"%{service}%")));
            }

            // Proyección a DTO (mejor que traer entidades completas)
            List<EmprendimientoDTO> result = await query
                .OrderBy(e => e.Nombre)
                .Select(e => new EmprendimientoDTO
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Descripcion = e.Descripcion,
                    Imagen = e.Imagen,

                    Estudio = e.Estudio == null ? null : new EstudioDTO
                    {
                        Id = e.Estudio.Id,
                        Titulo = e.Estudio.Titulo
                    },

                    Direccion = new DireccionDTO
                    {
                        Calle = e.Direccion.Calle,
                        Esquina = e.Direccion.Esquina,
                        NumeroPuerta = e.Direccion.NumeroPuerta,
                        Barrio = e.Direccion.Barrio,
                        Departamento = e.Direccion.Departamento
                    },

                    Servicios = e.Servicios
                        .Select(s => new ServicioDTO
                        {
                            Id = s.Id,
                            Nombre = s.Nombre,
                            Descripcion = s.Descripcion,
                            IconName = s.IconName,
                            Costo = s.Costo
                        })
                        .ToList(),

                    Portfolios = e.Portfolios
                        .Select(p => new PortfolioDTO
                        {
                            Titulo = p.Titulo,
                            Descripcion = p.Descripcion,
                            Fecha = p.Fecha,
                            ImagenUrl = p.Imagen
                        })
                        .ToList(),

                    ExAlumno = e.ExAlumno == null ? null : new ExAlumnoDTO
                    {
                        Id = e.Id,
                        Nombre = e.ExAlumno.Nombre,
                        Email = e.ExAlumno.Email,
                        Apellido = e.ExAlumno.Apellido,
                        AnioEgreso = e.ExAlumno.AnioEgreso,
                        Estudios = e.ExAlumno.Estudios
                            .Select(est => new EstudioDTO
                            {
                                Id = est.Id,
                                Titulo = est.Titulo
                            })
                            .ToList()
                    }
                })
                .ToListAsync();

            return result;
        }


    }
}
