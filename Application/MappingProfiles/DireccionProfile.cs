using Application.DTOs.Direccion;
using Application.DTOs.Disponibilidad;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class DireccionProfile : Profile
    {
        public DireccionProfile()
        {
            CreateMap<CreateDireccionDTO, Direccion>();
            CreateMap<Direccion, DireccionDTO>();
        }
    }
}
