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
    public class GetServiciosDeExAlumno : IGetServiciosDeExAlumno
    {
        private readonly IServicioRepository _servicioRepository;
        private readonly IMapper _mapper;

        public GetServiciosDeExAlumno(IServicioRepository servicioRepository, IMapper mapper)
        {
            _servicioRepository = servicioRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ServicioDTO>> ExecuteAsync(Guid ExAlumnoId)
        {
            IEnumerable<Servicio> servicios = await _servicioRepository.GetAllServicios(ExAlumnoId);
            IEnumerable<ServicioDTO> serviciosDTO = _mapper.Map<List<ServicioDTO>>(servicios);
            return serviciosDTO;
        }
    }
}
