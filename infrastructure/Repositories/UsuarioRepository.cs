using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UsuarioRepository> _logger;
        public UsuarioRepository(AppDbContext context, ILogger<UsuarioRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }

        public async Task<Usuario> GetUserByEmail(string email)
        {
            var sw = Stopwatch.StartNew();
            return await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == email);
            _logger.LogInformation("LOGIN DB user lookup: {ms} ms", sw.ElapsedMilliseconds);
        }

        public async Task<Usuario> GetUserById(Guid id)
        {
            return await _context.Usuarios
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id.Equals(id));

        }
    }
}
