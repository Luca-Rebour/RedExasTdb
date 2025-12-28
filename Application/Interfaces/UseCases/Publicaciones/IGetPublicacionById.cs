using Application.DTOs.Publicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Publicaciones
{
    public interface IGetPublicacionById
    {
        Task<PublicacionDTO> ExecuteAsync(Guid publicacionId);
    }
}
