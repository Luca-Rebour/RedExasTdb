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
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AppDbContext _context;
        public EmpresaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Empresa> CreateEmpresaAsync(Empresa empresa)
        {
            await _context.Empresas.AddAsync(empresa);
            return empresa;
        }

        public async Task<Empresa> getEmpresaByIdAsync(Guid empresaId)
        {
            return await _context.Empresas.FirstOrDefaultAsync(e => e.Id.Equals(empresaId));
        }
    }
}
