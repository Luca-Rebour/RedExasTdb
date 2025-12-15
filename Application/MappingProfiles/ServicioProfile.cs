using Application.DTOs.Disponibilidad;
using Application.DTOs.Servicio;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class ServicioProfile : Profile
    {
        public ServicioProfile()
        {
            CreateMap<Servicio, ServicioDTO>();

        }
    }
}
