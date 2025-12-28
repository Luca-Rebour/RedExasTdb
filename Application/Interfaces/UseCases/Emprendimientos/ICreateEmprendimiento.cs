using Application.DTOs.Emprendimiento;
using Application.DTOs.ExAlumno;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Emprendimientos
{
    public interface ICreateEmprendimiento
    {
        Task<EmprendimientoDTO> ExecuteAsync(CreateEmprendimientoDTO emprendimientoDTO, Guid userId);
    }
}
