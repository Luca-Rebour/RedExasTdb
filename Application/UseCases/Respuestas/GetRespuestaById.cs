using Application.DTOs.Repuesta;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.Respuestas;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Respuestas
{
    public class GetRespuestaById : IGetRespuestaById
    {
        private readonly IRespuestaRepository _respuestaRepository;
        private readonly IMapper _mapper;
        public GetRespuestaById(IRespuestaRepository respuestaRepository, IMapper mapper)
        {
            _respuestaRepository = respuestaRepository;
            _mapper = mapper;
        }
        public async Task<RespuestaDTO> ExecuteAsync(Guid respuestaId)
        {
            RespuestaDTO respuestaDTO = _mapper.Map<RespuestaDTO>(await _respuestaRepository.GetRespuestaAsync(respuestaId));
            if (respuestaDTO == null)
            {
                throw new NotFoundException("Respuesta", respuestaId);
            }
            return respuestaDTO;
        }
    }
}
