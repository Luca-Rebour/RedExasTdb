using Application.Interfaces.Repositories;
using Domain.Entities;
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
    }
}
