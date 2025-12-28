using Application.DTOs.Empresa;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.Empresas;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Empresas
{
    public class GetEmpresaById : IGetEmpresaById
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        public GetEmpresaById(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }
        public async Task<EmpresaDTO> ExecuteAsync(Guid empresaId)
        {
            Empresa empresa = await _empresaRepository.getEmpresaByIdAsync(empresaId);
            if (empresa == null)
            {
                throw new NotFoundException("Empresa", empresaId);
            }

            return _mapper.Map<EmpresaDTO>(empresa);
        }
    }
}
