using Application.DTOs.ExAlumno;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.ExAlumnos;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ExAlumnos
{
    public class CreateExAlumno : ICreateExAlumno
    {
        private readonly IExAlumnoRepository _exAlumnoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public CreateExAlumno(IExAlumnoRepository exAlumnoRepository, IMapper mapper, IPasswordService passwordService, IUsuarioRepository usuarioRepository)
        {
            _exAlumnoRepository = exAlumnoRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ExAlumnoDTO> ExecuteAsync(CreateExAlumnoDTO exAlumnoDTO)
        {
            if (await _usuarioRepository.ExisteEmailAsync(exAlumnoDTO.Email))
            {
                throw new EmailAlreadyExistsException(exAlumnoDTO.Email);
            }
            exAlumnoDTO.Validate();
            exAlumnoDTO.Contrasena = _passwordService.HashPassword(exAlumnoDTO.Contrasena);
            ExAlumno exAlumno = _mapper.Map<ExAlumno>(exAlumnoDTO);
            await _exAlumnoRepository.CreateExAlumnoAsync(exAlumno);
            return _mapper.Map<ExAlumnoDTO>(exAlumno);
        }
    }
}
