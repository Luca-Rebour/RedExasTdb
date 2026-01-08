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
    public class PublicacionRepository : IPublicacionRepository
    {
        private AppDbContext _context;

        public PublicacionRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePublicacion(Publicacion publicacion)
        {
            _context.Publicaciones.Add(publicacion);
        }

        public void DeletePublicacion(Publicacion publicacion)
        {
            _context.Publicaciones.Remove(publicacion);
        }

        public async Task<Publicacion> GetPublicacionAsync(Guid publicacionId)
        {
            return await _context.Publicaciones
                    .AsNoTracking()
                    .Include(p => p.ExAlumno)
                        .ThenInclude(e => e.Estudios)
                    .FirstOrDefaultAsync(p => p.Id.Equals(publicacionId));
        }

        public void UpdatePublicacion(Publicacion publicacion)
        {
            _context.Update(publicacion);
        }

        public async Task<List<Publicacion>> GetPublicacionesAsync(int skip = 0, int take = 50)
        {
            return await _context.Publicaciones
                        .AsNoTracking()
                        .Include(p => p.ExAlumno)
                            .ThenInclude(e => e.Estudios)
                        .OrderByDescending(p => p.Fecha)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }
    }
}
