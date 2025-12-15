using Application.DTOs.Servicio;
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
    public class ServicioRepository : IServicioRepository
    {
        private AppDbContext _context;
        public ServicioRepository(AppDbContext context) 
        { 
            _context = context;
        }
        public Task<Servicio> CreateServicio(ServicioDTO servicio)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Servicio>> GetAllServicios(Guid IdExAlumno)
        {
            return await _context.Servicios
                .Include(s => s.Emprendimiento)
                .Where(s => s.Emprendimiento.ExAlumnoId == IdExAlumno).ToListAsync();

        }
    }
}
