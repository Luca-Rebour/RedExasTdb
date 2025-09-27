using Application.DTOs.Emprendimiento;
using Application.DTOs.ExAlumnos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.Emprendimientos;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Emprendimientos
{
    public class CreateEmprendimiento : ICreateEmprendimiento
    {
        private readonly IEmprendimientoRepository _emprendimientoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public CreateEmprendimiento(IEmprendimientoRepository emprendimientoRepository, IMapper mapper, IPasswordService passwordService, IUsuarioRepository usuarioRepository)
        {
            _emprendimientoRepository = emprendimientoRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Emprendimiento> ExecuteAsync(CreateEmprendimientoDTO emprendimientoDTO)
        {
            Emprendimiento emprendimiento = _mapper.Map<Emprendimiento>(emprendimientoDTO);
            await _emprendimientoRepository.CreateEmprendimientoAsync(emprendimiento);
            return emprendimiento;
        }
    }
}
