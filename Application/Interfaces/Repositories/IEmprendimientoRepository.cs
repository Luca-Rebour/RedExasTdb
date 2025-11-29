using Application.DTOs.Emprendimiento;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IEmprendimientoRepository
    {
        Task<Emprendimiento> CreateEmprendimientoAsync(Emprendimiento emprendimiento);
        Task<List<Emprendimiento>> GetAllEmprendimientosAsync();
        Task<List<Emprendimiento>> GetEmprendimientosDeExAlumnoAsync(Guid userId);
        Task<List<EmprendimientoDTO>> SearchEmprendimientoAsync(string? query, Guid? estudioId);
    }
}
