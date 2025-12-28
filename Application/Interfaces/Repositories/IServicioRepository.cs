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
        Task<List<Servicio>> GetAllServiciosExAlumno(Guid IdExAlumno);
        Task<Servicio> CreateServicio(Servicio servicio);// CREA EL SERVICIO Y LO GUARDA
        Servicio AddServicio(Servicio servicio); // CREA EL SERVICIO PERO NO LO GUARDA
        Task<Servicio> GetServicioById(Guid servicioId);
    }
}
