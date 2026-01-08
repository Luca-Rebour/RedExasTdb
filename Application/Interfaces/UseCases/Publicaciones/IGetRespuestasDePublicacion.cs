using Application.DTOs.Publicacion;
using Application.DTOs.Repuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Publicaciones
{
    public interface IGetRespuestasDePublicacion
    {
        Task<IEnumerable<RespuestaDTO>> ExecuteAsync(Guid publicacionId);
    }
}
