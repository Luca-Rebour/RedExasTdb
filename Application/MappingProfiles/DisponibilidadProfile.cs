using Application.DTOs.Disponibilidad;
using Application.DTOs.Empresa;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class DisponibilidadProfile : Profile
    {
        public DisponibilidadProfile()
        {
            CreateMap<CreateDisponibilidadDTO, Disponibilidad>();
            CreateMap<CreateDisponibilidadDiaDTO, DisponibilidadDia>();

            CreateMap<Disponibilidad, DisponibilidadDTO>();
            CreateMap<DisponibilidadDia, DisponibilidadDiaDTO>();
        }
    }
}
