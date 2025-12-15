using Application.DTOs.Servicio;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> GetAllServicios(Guid IdExAlumno);
        Task<Servicio> CreateServicio(ServicioDTO servicio);
    }
}
