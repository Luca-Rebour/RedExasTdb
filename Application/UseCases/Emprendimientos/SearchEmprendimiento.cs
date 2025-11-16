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
    public class SearchEmprendimiento : ISearchEmprendimiento
    {
        private readonly IEmprendimientoRepository _emprendimientoRepository;
        private readonly IMapper _mapper;
        public SearchEmprendimiento(IEmprendimientoRepository emprendimientoRepository, IMapper mapper)
        {
            _emprendimientoRepository = emprendimientoRepository;
            _mapper = mapper;
        }
        public async Task<List<EmprendimientoDTO>> ExecuteAsync(string query)
        {
            List<EmprendimientoDTO> emprendimientoDTOs = await _emprendimientoRepository.SearchEmprendimientoAsync(query);
            return emprendimientoDTOs;
        }
    }
}
