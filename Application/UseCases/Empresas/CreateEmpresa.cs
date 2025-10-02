using Application.DTOs.Empresa;
using Application.DTOs.ExAlumnos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.Empresas;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Empresas
{
    public class CreateEmpresa : ICreateEmpresa
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IUsuarioRepository _usuarioRepository;
        public CreateEmpresa(IEmpresaRepository empresaRepository, IMapper mapper, IPasswordService passwordService, IUsuarioRepository usuarioRepository)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<EmpresaDTO> ExecuteAsync(CreateEmpresaDTO createEmpresaDTO)
        {
            if (await _usuarioRepository.ExisteEmailAsync(createEmpresaDTO.Email))
            {
                throw new EmailAlreadyExistsException(createEmpresaDTO.Email);
            }
            createEmpresaDTO.Validate();
            createEmpresaDTO.Contrasena = _passwordService.HashPassword(createEmpresaDTO.Contrasena);
            Empresa empresa = _mapper.Map<Empresa>(createEmpresaDTO);
            await _empresaRepository.CreateEmpresaAsync(empresa);
            return _mapper.Map<EmpresaDTO>(empresa);

        }
    }
}
