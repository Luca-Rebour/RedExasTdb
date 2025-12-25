using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RespuestaRepository : IRespuestaRepository
    {
        private AppDbContext _context;
        public RespuestaRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateRespuesta(Respuesta respuesta)
        {
            _context.Respuestas.Add(respuesta);
        }
    }
}
