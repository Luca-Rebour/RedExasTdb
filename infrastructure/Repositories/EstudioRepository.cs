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
    public class EstudioRepository : IEstudioRepository
    {
        private AppDbContext _context;

        public EstudioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Estudio>> GetEstudios()
        {
            return await _context.Estudios.ToListAsync();
        }
    }
}
