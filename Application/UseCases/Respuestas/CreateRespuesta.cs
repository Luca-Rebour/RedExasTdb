using Application.DTOs.Repuesta;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.Respuestas;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Respuestas
{
    public class CreateRespuesta : ICreateRespuesta
    {
        private readonly IRespuestaRepository _respuestaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public CreateRespuesta(IRespuestaRepository respuestaRepository, IMapper mapper, IUnitOfWork uow)
        {
            _respuestaRepository = respuestaRepository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<RespuestaDTO> ExecuteAsync(CreateRespuestaDTO createRespuestaDTO, Guid userId)
        {
            createRespuestaDTO.Validate();
            Respuesta respuesta = _mapper.Map<Respuesta>(createRespuestaDTO);
            respuesta.SetExAlumnoId(userId);
            _respuestaRepository.CreateRespuesta(respuesta);
            await _uow.SaveChangesAsync();
            return _mapper.Map<RespuestaDTO>(respuesta);
        }
    }
}
