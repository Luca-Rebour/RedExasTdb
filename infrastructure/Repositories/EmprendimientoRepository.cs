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

        public async Task<List<Emprendimiento>> GetAllEmprendimientoAsync()
        {
            return await _context.Emprendimientos.Include(e => e.ExAlumno).ToListAsync();
        }
    }
}
