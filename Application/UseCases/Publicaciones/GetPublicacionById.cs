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
    public class GetPublicacionById : IGetPublicacionById
    {
        private readonly IPublicacionRepository _publicacionRepository;
        private readonly IMapper _mapper;
        public GetPublicacionById(IPublicacionRepository publicacionRepository, IMapper mapper)
        {
            _publicacionRepository = publicacionRepository;
            _mapper = mapper;
        }
        public async Task<PublicacionDTO> ExecuteAsync(Guid publicacionId)
        {
            Publicacion publicacion = await _publicacionRepository.GetPublicacionAsync(publicacionId);

            if (publicacion is null)
                throw new Exception("Publicación no encontrada");

            return _mapper.Map<PublicacionDTO>(publicacion);
        }

    }
}
