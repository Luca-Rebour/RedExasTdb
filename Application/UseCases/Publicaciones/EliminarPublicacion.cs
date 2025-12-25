using Application.DTOs.Publicacion;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.Publicaciones;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Publicaciones
{
    public class EliminarPublicacion : IEliminarPublicacion
    {
        private readonly IPublicacionRepository _publicacionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public EliminarPublicacion(IPublicacionRepository publicacionRepository, IMapper mapper, IUnitOfWork uow)
        {
            _publicacionRepository = publicacionRepository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<bool> ExecuteAsync(Guid publicacionId, Guid userId)
        {
            Publicacion publicacionAEliminar = await _publicacionRepository.GetPublicacionAsync(publicacionId);
            if (publicacionAEliminar.ExAlumnoId != userId)
            {
                throw new UnauthorizedAccessException("No tienes los permisos necesarios para eliminar esta publicacion");
            }
            _publicacionRepository.DeletePublicacion(publicacionAEliminar);
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}
