using Application.DTOs.Emprendimiento;
using Application.DTOs.Estudio;
using Application.DTOs.ExAlumnos;
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
            return emprendimiento;
        }

        public async Task<List<Emprendimiento>> GetAllEmprendimientosAsync()
        {
            return await _context.Emprendimientos.Include(e => e.ExAlumno).ToListAsync();
        }

        public async Task<List<Emprendimiento>> GetEmprendimientosDeExAlumnoAsync(Guid userId)
        {
            return await _context.Emprendimientos.Include(e => e.ExAlumno).Where(e => e.ExAlumnoId.Equals(userId)).ToListAsync();
        }

        public async Task<List<EmprendimientoDTO>> SearchEmprendimientoAsync(string query)
        {
            var result =
                from e in _context.Emprendimientos
                join s in _context.Servicios
                    on e.Id equals s.EmprendimientoId into serviciosGroup
                from s in serviciosGroup.DefaultIfEmpty() // LEFT JOIN
                join ex in _context.ExAlumnos
                    on e.ExAlumnoId equals ex.Id
                where EF.Functions.ILike(e.Ubicacion, $"%{query}%")
                   || EF.Functions.ILike(e.Nombre, $"%{query}%")
                   || (s != null && EF.Functions.ILike(s.Nombre, $"%{query}%"))
                select new EmprendimientoDTO
                {
                    IdEmprendimiento = e.Id,
                    IdServicio = s != null ? s.Id : Guid.Empty,
                    NombreEmprendimiento = e.Nombre,
                    DescripcionEmprendimiento = e.Descripcion,
                    UbicacionEmprendimiento = e.Ubicacion,
                    NombreServicio = s != null ? s.Nombre : string.Empty,
                    DescripcionServicio = s != null ? s.Descripcion : string.Empty,
                    ExAlumno = new ExAlumnoDTO
                    {
                        AnioEgreso = ex.AnioEgreso,
                        Nombre = ex.Nombre,
                        Apellido = ex.Apellido,
                        Categoria = ex.Categoria,
                        CategoriaId = ex.CategoriaId,
                        Estudios = ex.Estudios
                            .Select(est => new EstudioDTO
                            {
                                Id = est.Id,
                                Titulo = est.Titulo
                            })
                            .ToList()
                    }
                };

            return await result.ToListAsync();
        }




    }
}
