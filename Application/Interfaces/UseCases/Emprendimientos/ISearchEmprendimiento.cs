using Application.DTOs.Emprendimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Emprendimientos
{
    public interface ISearchEmprendimiento
    {
        Task<List<EmprendimientoDTO>> ExecuteAsync(string query);
    }
}
