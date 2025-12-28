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
    public class DeleteRespuesta : IDeleteRespuesta
    {
        private readonly IRespuestaRepository _respuestaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public DeleteRespuesta(IRespuestaRepository respuestaRepository, IMapper mapper, IUnitOfWork uow)
        {
            _respuestaRepository = respuestaRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<bool> ExecuteAsync(Guid respuestaId, Guid userId)
        {
            Respuesta respuestaAEliminar = await _respuestaRepository.GetRespuestaAsync(respuestaId) ?? throw new NotFoundException("Respuesta", respuestaId); ;
            if (respuestaAEliminar.ExAlumnoId != userId)
            {
                throw new UnauthorizedAccessException("No tienes aceso a eliminar esta respuesta");
            }

            _respuestaRepository.DeleteRespuesta(respuestaAEliminar);
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}
