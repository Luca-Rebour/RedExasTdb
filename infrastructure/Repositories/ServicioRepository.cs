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
        private readonly AppDbContext _context;
        public ServicioRepository(AppDbContext context) 
        { 
            _context = context;
        }
        public async Task<Servicio> CreateServicio(Servicio servicio) // CREA EL SERVICIO Y LO GUARDA
        {
            _context.Add(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }

        public Servicio AddServicio(Servicio servicio) // CREA EL SERVICIO PERO NO LO GUARDA
        {
            _context.Add(servicio);
            return servicio;
        }

        public async Task<List<Servicio>> GetAllServiciosExAlumno(Guid IdExAlumno)
        {
            return await _context.Servicios
                .Include(s => s.Emprendimiento)
                .Where(s => s.Emprendimiento.ExAlumnoId == IdExAlumno).ToListAsync();

        }
    }
}
