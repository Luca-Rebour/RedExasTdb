using Application.DTOs.Repuesta;
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
    public class GetRespuestasDePublicacion : IGetRespuestasDePublicacion
    {
        private readonly IRespuestaRepository _respuestaRepository;
        private readonly IMapper _mapper;
        public GetRespuestasDePublicacion(IRespuestaRepository respuestaRepository, IMapper mapper)
        {
            _respuestaRepository = respuestaRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RespuestaDTO>> ExecuteAsync(Guid publicacionId)
        {
            IEnumerable<RespuestaDTO> respuestas = _mapper.Map<IEnumerable<RespuestaDTO>>(await _respuestaRepository.GetRespuestasDePublicacion(publicacionId));
            return respuestas;
        }
    }
}
