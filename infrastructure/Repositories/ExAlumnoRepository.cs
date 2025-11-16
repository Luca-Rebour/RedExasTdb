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
    public class ExAlumnoRepository : IExAlumnoRepository
    {
        private readonly AppDbContext _context;

        public ExAlumnoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ExAlumno> CreateExAlumnoAsync(ExAlumno exAlumno)
        {
            await _context.ExAlumnos.AddAsync(exAlumno);
            await _context.SaveChangesAsync();
            return exAlumno;
        }

        public async Task<List<ExAlumno>> GetAllExAlumnosAsync()
        {
            return await _context.ExAlumnos.ToListAsync();
        }
    }
}
