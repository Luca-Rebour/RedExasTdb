using Application.DTOs.Estudio;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Estudios;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Estudios
{
    public class GetAllEstudios : IGetAllEstudios
    {
        private IEstudioRepository _estudioRepository;
        private IMapper _mapper;
        public GetAllEstudios(IEstudioRepository estudioRepository, IMapper mapper) {
        
            _estudioRepository = estudioRepository;
            _mapper = mapper;
        }
        public async Task<List<EstudioDTO>> ExecuteAsync()
        {
            List<Estudio> estudios = await _estudioRepository.GetEstudios();
            return _mapper.Map<List<EstudioDTO>>(estudios);
        }
    }
}
