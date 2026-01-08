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
    public class CreatePublicacion : ICreatePublicacion
    {
        private readonly IPublicacionRepository _publicacionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public CreatePublicacion(IPublicacionRepository publicacionRepository, IMapper mapper, IUnitOfWork uow)
        {
            _publicacionRepository = publicacionRepository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<PublicacionDTO> ExecuteAsync(CreatePublicacionDTO createPublicacionDTO, Guid userId)
        {
            createPublicacionDTO.ExAlumnoId = userId;
            createPublicacionDTO.Validate();
            Publicacion p = _mapper.Map<Publicacion>(createPublicacionDTO);
            _publicacionRepository.CreatePublicacion(p);
            await _uow.SaveChangesAsync();
             p = await _publicacionRepository.GetPublicacionAsync(p.Id);
            return _mapper.Map<PublicacionDTO>(p);
        }
    }
}
