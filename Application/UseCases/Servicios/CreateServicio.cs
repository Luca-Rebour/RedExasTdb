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
        private readonly IMapper _mapper;

        public CreateServicio(IServicioRepository servicioRepository, IMapper mapper)
        {
            _servicioRepository = servicioRepository;
            _mapper = mapper;
        }
        public async Task<ServicioDTO> ExecuteAsync(CreateServicioDTO createServicioDTO)
        {
            createServicioDTO.Validate();
            Servicio nuevoServicio = _mapper.Map<Servicio>(createServicioDTO);
            await _servicioRepository.CreateServicio(nuevoServicio);
            return _mapper.Map<ServicioDTO>(nuevoServicio);
        }
    }
}
