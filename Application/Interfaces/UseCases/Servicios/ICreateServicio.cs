using Application.DTOs.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Servicios
{
    public interface ICreateServicio
    {
        Task<ServicioDTO> ExecuteAsync(CreateServicioDTO createServicioDTO, Guid userId);
    }
}
