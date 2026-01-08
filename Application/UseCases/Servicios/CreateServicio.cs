using Application.DTOs.Servicio;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Servicios;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Servicios
{
    public class CreateServicio : ICreateServicio
    {
        private readonly IServicioRepository _servicioRepository;
        private readonly IEmprendimientoRepository _emprendimientoRepository;
        private readonly IMapper _mapper;

        public CreateServicio(IServicioRepository servicioRepository, IMapper mapper, IEmprendimientoRepository emprendimientoRepository)
        {
            _servicioRepository = servicioRepository;
            _mapper = mapper;
            _emprendimientoRepository = emprendimientoRepository;
        }
        public async Task<ServicioDTO> ExecuteAsync(CreateServicioDTO createServicioDTO, Guid userId)
        {
            createServicioDTO.Validate();
            Servicio nuevoServicio = _mapper.Map<Servicio>(createServicioDTO);
            Emprendimiento emprendimiento = await _emprendimientoRepository.GetEmprendimientoById(nuevoServicio.EmprendimientoId);
            if (!emprendimiento.ExAlumnoId.Equals(userId))
            {
                throw new UnauthorizedAccessException("El usuario no tiene permisos para agregar un servicio a este emprendimiento.");
            }
            await _servicioRepository.CreateServicio(nuevoServicio);
            return _mapper.Map<ServicioDTO>(nuevoServicio);
        }
    }
}
