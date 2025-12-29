using Application.DTOs.Publicacion;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Publicaciones;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Publicaciones
{
    public class GetPublicaciones : IGetPublicaciones
    {
        private readonly IPublicacionRepository _publicacionRepository;
        private readonly IMapper _mapper;
        public GetPublicaciones(IPublicacionRepository publicacionRepository, IMapper mapper)
        {
            _publicacionRepository = publicacionRepository;
            _mapper = mapper;
        }
        // SI LOS VALORES VIENEN NULL, SE DEVUELVEN LAS PRIMERAS 50 PUBLICACIONES POR DEFECTO
        public async Task<List<PublicacionDTO>> ExecuteAsync(int skip, int take)
        {
            return _mapper.Map<List<PublicacionDTO>>(await _publicacionRepository.GetPublicacionesAsync(skip, take));
        }
    }
}
