using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<bool> ExisteEmailAsync(string email);
        Task<Usuario> GetUserByEmail(string email);
    }
}
