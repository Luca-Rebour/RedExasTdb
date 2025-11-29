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

        public async Task<EmprendimientoDTO> ExecuteAsync(CreateEmprendimientoDTO emprendimientoDTO, Guid userId)
        {
            emprendimientoDTO.validate();
            Emprendimiento emprendimiento = _mapper.Map<Emprendimiento>(emprendimientoDTO);
            emprendimiento.Disponibilidad.setEmprendimientoId(emprendimiento.Id);

            emprendimiento.setExAlumnoId(userId);
            foreach (DisponibilidadDia disponibilidadDia in emprendimiento.Disponibilidad.Dias)
            {
                disponibilidadDia.setDispoinibilidadId(emprendimiento.Disponibilidad.Id);
            }
            emprendimiento = await _emprendimientoRepository.CreateEmprendimientoAsync(emprendimiento);
            EmprendimientoDTO emprendimientoCreadoDTO = _mapper.Map<EmprendimientoDTO>(emprendimiento);
            return emprendimientoCreadoDTO;
        }
    }
}
