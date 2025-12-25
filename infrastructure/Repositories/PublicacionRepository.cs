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
                    .FindAsync(publicacionId);
        }

        public void UpdatePublicacion(Publicacion publicacion)
        {
            _context.Update(publicacion);
        }
    }
}
