using Application.DTOs.Emprendimiento;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Emprendimientos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Emprendimientos
{
    public class GetAllEmprendimientos : IGetAllEmprendimientos
    {
        private readonly IEmprendimientoRepository _emprendimientoRepository;
        private readonly IMapper _mapper;
        public GetAllEmprendimientos(IEmprendimientoRepository emprendimientoRepository, IMapper mapper)
        {
            _emprendimientoRepository = emprendimientoRepository;
            _mapper = mapper;
        }

        public async Task<List<EmprendimientoDTO>> ExecuteAsync()
        {
            List<Emprendimiento> emprendimientos = await _emprendimientoRepository.GetAllEmprendimientoAsync();
            List<EmprendimientoDTO> emprendimientoDTOs = _mapper.Map<List<EmprendimientoDTO>>(emprendimientos);
            return emprendimientoDTOs;
        }
    }
}
