using Application.DTOs.Emprendimiento;
using Application.Interfaces.Repositories;
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
    public class GetEmprendimientoById : IGetEmprendimientoById
    {
        private readonly IEmprendimientoRepository _emprendimientoRepository;
        private readonly IMapper _mapper;
        public GetEmprendimientoById(IEmprendimientoRepository emprendimientoRepository, IMapper mapper)
        {
            _emprendimientoRepository = emprendimientoRepository;
            _mapper = mapper;
        }

        public async Task<EmprendimientoDTO> ExecuteAsync(Guid emprendimientoId)
        {
            Emprendimiento emprendimiento = await _emprendimientoRepository.GetEmprendimientoById(emprendimientoId);
            if (emprendimiento == null)
            {
                throw new NotFoundException("Emprendimiento", emprendimientoId);
            }

            return _mapper.Map<EmprendimientoDTO>(emprendimiento);
        }
    }
}
