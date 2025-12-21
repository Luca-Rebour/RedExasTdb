using Application.DTOs.Emprendimiento;
using Application.DTOs.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Emprendimientos
{
    public interface IGetServiciosDeEmprendimiento
    {
        Task<List<ServicioDTO>> ExecuteAsync(Guid emprendimientoId);
    }
}
