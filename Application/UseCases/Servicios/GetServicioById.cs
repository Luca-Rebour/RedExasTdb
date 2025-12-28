using Application.DTOs.Servicio;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Servicios;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Servicios
{
    public class GetServicioById : IGetServicioById
    {
        private readonly IServicioRepository _servicioRepository;
        private readonly IMapper _mapper;

        public GetServicioById(IServicioRepository servicioRepository, IMapper mapper)
        {
            _servicioRepository = servicioRepository;
            _mapper = mapper;
        }
        public async Task<ServicioDTO> ExecuteAsync(Guid servicioId)
        {
            Servicio servicio = await _servicioRepository.GetServicioById(servicioId);
            if (servicio == null)
            {
                throw new NotFoundException("Servicio", servicioId);
            }

            return _mapper.Map<ServicioDTO>(servicio);
        }
    }
}
