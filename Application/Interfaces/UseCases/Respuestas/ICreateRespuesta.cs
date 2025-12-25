using Application.DTOs.Publicacion;
using Application.DTOs.Repuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Respuestas
{
    public interface ICreateRespuesta
    {
        Task<RespuestaDTO> ExecuteAsync(CreateRespuestaDTO createRespuestaDTO, Guid userId);
    }
}
