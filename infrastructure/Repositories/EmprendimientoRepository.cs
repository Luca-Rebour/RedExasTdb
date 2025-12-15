using Application.DTOs.Emprendimiento;
using Application.DTOs.Estudio;
using Application.DTOs.ExAlumnos;
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
        public async Task<Emprendimiento> CreateEmprendimientoAsync(Emprendimiento emprendimiento)
        {
            await _context.Emprendimientos.AddAsync(emprendimiento);
            await _context.SaveChangesAsync();

            await _context.Entry(emprendimiento)
                .Reference(e => e.ExAlumno)
                .LoadAsync();

            await _context.Entry(emprendimiento)
                .Reference(e => e.Estudio)
                .LoadAsync();

            return emprendimiento;
        }

        public async Task<List<Emprendimiento>> GetAllEmprendimientosAsync()
        {
            return await _context.Emprendimientos.Include(e => e.ExAlumno).Include(d => d.Disponibilidad).Include(d => d.Disponibilidad.Dias).Include(s => s.servicios).ToListAsync();
        }

        public async Task<List<Emprendimiento>> GetEmprendimientosDeExAlumnoAsync(Guid userId)
        {
            return await _context.Emprendimientos.Include(e => e.ExAlumno).Where(e => e.ExAlumnoId.Equals(userId)).ToListAsync();
        }

        public async Task<List<EmprendimientoDTO>> SearchEmprendimientoAsync(
            string? query,
            Guid? estudioId
        )
        {
            /*    query ??= string.Empty;

                var flat = await (
                    from e in _context.Emprendimientos
                    join est in _context.Estudios
                        on e.EstudioId equals est.Id
                    join s in _context.Servicios
                        on e.Id equals s.EmprendimientoId into serviciosGroup
                    from s in serviciosGroup.DefaultIfEmpty()
                    join ex in _context.ExAlumnos
                        on e.ExAlumnoId equals ex.Id
                    where
                        // búsqueda por texto: departamento, dirección o nombre del emprendimiento
                        (string.IsNullOrEmpty(query)
                            || EF.Functions.ILike(e.Departamento, $"%{query}%")
                            || EF.Functions.ILike(e.Direccion, $"%{query}%")
                            || EF.Functions.ILike(e.Nombre, $"%{query}%")
                        )
                        // filtro por tipo de emprendimiento (Estudio)
                        && (!estudioId.HasValue || est.Id.Equals(estudioId))
                    select new
                    {
                        Emprendimiento = e,
                        Servicio = s,
                        ExAlumno = ex,
                        Estudio = est
                    }
                ).ToListAsync();

                var result = flat
                    .GroupBy(x => x.Emprendimiento.Id)
                    .Select(g =>
                    {
                        var first = g.First();

                        return new EmprendimientoDTO
                        {
                            Id = first.Emprendimiento.Id,

                            Nombre = first.Emprendimiento.Nombre,
                            Descripcion = first.Emprendimiento.Descripcion,
                            Direccion = first.Emprendimiento.Direccion,

                            Estudio = new EstudioDTO
                            {
                                Id = first.Estudio.Id,
                                Titulo = first.Estudio.Titulo
                            },

                            servicios = g
                                .Where(x => x.Servicio != null)
                                .Select(x => new ServicioDTO
                                {
                                    Id = x.Servicio.Id,
                                    Nombre = x.Servicio.Nombre,
                                    Descripcion = x.Servicio.Descripcion
                                })
                                .ToList(),

                            ExAlumno = new ExAlumnoDTO
                            {
                                AnioEgreso = first.ExAlumno.AnioEgreso,
                                Nombre = first.ExAlumno.Nombre,
                                Apellido = first.ExAlumno.Apellido,
                                Estudios = first.ExAlumno.Estudios
                                    .Select(est => new EstudioDTO
                                    {
                                        Id = est.Id,
                                        Titulo = est.Titulo
                                    })
                                    .ToList()
                            }
                        };
                    })
                    .ToList();

                return result;
            */

            return null;
        }

    }
}
