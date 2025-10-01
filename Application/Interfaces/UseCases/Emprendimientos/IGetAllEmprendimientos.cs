using Application.DTOs.Emprendimiento;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Emprendimientos
{
    public interface IGetAllEmprendimientos
    {
        Task<List<EmprendimientoDTO>> ExecuteAsync();
    }
}
