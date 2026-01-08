using Application.DTOs.AuthResult;
using Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Usuario
{
    public interface IMe
    {
        Task<UsuarioDTO> ExecuteAsync(Guid userId);
    }
}
