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
    public class RespuestaRepository : IRespuestaRepository
    {
        private readonly AppDbContext _context;
        public RespuestaRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateRespuesta(Respuesta respuesta)
        {
            _context.Respuestas.Add(respuesta);
        }

        public void DeleteRespuesta(Respuesta respuesta)
        {
            _context.Respuestas.Remove(respuesta);
        }

        public async Task<Respuesta> GetRespuestaAsync(Guid respuestaId)
        {
            Respuesta respuesta =  await _context.Respuestas
                .Include(p => p.Publicacion)                
                .FirstOrDefaultAsync(r => r.Id.Equals(respuestaId));
            return respuesta;
        }
    }
}
