using Application.DTOs.Servicio;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Emprendimientos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Emprendimientos
{
    public class GetServiciosDeEmprendimiento : IGetServiciosDeEmprendimiento
    {
        private readonly IEmprendimientoRepository _emprendimientoRepository;
        private readonly IMapper _mapper;
        public GetServiciosDeEmprendimiento(IEmprendimientoRepository emprendimientoRepository, IMapper mapper)
        {
            _emprendimientoRepository = emprendimientoRepository;
            _mapper = mapper;
        }

        public async Task<List<ServicioDTO>> ExecuteAsync(Guid emprendimientoId)
        {
            return _mapper.Map<List<ServicioDTO>>( await _emprendimientoRepository.GetServiciosDeEmprendimiento(emprendimientoId));
        }
    }
}
