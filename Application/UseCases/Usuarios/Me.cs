using Application.DTOs.Administrador;
using Application.DTOs.AuthResult;
using Application.DTOs.Empresa;
using Application.DTOs.ExAlumno;
using Application.DTOs.Usuario;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.Auth;
using Application.Interfaces.UseCases.Usuario;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Usuarios
{
    public class Me : IMe
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SignIn> _logger;

        public Me(IUsuarioRepository usuarioRepository, IMapper mapper, ILogger<SignIn> logger)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UsuarioDTO> ExecuteAsync(Guid userId)
        {
            Usuario user = await _usuarioRepository.GetUserById(userId);

            string rol = user switch
            {
                Empresa => "Empresa",
                ExAlumno => "ExAlumno",
                Administrador => "Administrador",
                _ => throw new InvalidOperationException("Tipo de usuario desconocido")
            };

            object details = user switch
            {
                Empresa e => _mapper.Map<EmpresaDTO>(e),
                ExAlumno x => _mapper.Map<ExAlumnoDTO>(x),
                Administrador a => _mapper.Map<AdministradorDTO>(a),
                _ => throw new InvalidOperationException("Tipo de usuario desconocido")
            };

            return new UsuarioDTO(rol, details);
        }
    }  
}
