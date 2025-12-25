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
    public class EditarPublicacion : IEditarPublicacion
    {
        private readonly IPublicacionRepository _publicacionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public EditarPublicacion(IPublicacionRepository publicacionRepository, IMapper mapper, IUnitOfWork uow)
        {
            _publicacionRepository = publicacionRepository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<PublicacionDTO> ExecuteAsync(EditarPublicacionDTO editarPublicacionDTO, Guid publicacionId, Guid userId)
        {
            editarPublicacionDTO.Validate();
            Publicacion publicacion = await _publicacionRepository.GetPublicacionAsync(publicacionId);

            if (publicacion is null)
                throw new Exception("Publicación no encontrada");

            if (publicacion.ExAlumnoId != userId)
                throw new UnauthorizedAccessException("No tienes permisos para actualizar esta publicacion");

            _mapper.Map(editarPublicacionDTO, publicacion);

            await _uow.SaveChangesAsync();

            return _mapper.Map<PublicacionDTO>(publicacion);
        }

    }
}
