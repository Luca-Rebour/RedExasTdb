using Application.DTOs.AuthResult;
using Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Auth
{
    public interface ISignIn
    {
        Task<SignInResultDTO> ExecuteAsync(SignInDTO signInDTO);
    }
}
