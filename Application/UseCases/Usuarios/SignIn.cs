using Application.DTOs.AuthResult;
using Application.DTOs.Usuario;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.Auth;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Usuarios
{
    public class SignIn : ISignIn
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;

        public SignIn(IUsuarioRepository usuarioRepository, IMapper mapper, IPasswordService passwordService, IJwtService jwtService)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }

        public async Task<SignInResultDTO> ExecuteAsync(SignInDTO signInDTO)
        {
            Usuario user = await _usuarioRepository.GetUserByEmail(signInDTO.Email);

            if (user == null || !_passwordService.VerifyPassword(user.Contrasena, signInDTO.Contrasena))
            {
                return SignInResultDTO.Fail("Email o contraseña inválidos");
            }

            string rol = user switch
                    {
                        Empresa => "Empresa",
                        ExAlumno => "ExAlumno",
                        Administrador => "Administrador",
                        _ => throw new InvalidOperationException("Tipo de usuario desconocido")
                    };

            var token = _jwtService.GenerateToken(user.Id, user.Email, rol);
            return SignInResultDTO.SuccessResult(token);
        }
    }
}
