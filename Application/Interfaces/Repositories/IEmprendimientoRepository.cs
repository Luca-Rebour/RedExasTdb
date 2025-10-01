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
        Task<List<Emprendimiento>> GetAllEmprendimientoAsync();
    }
}
