using Application.DTOs.Administrador;
using Application.DTOs.Direccion;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class AdministradorProfile : Profile
    {
        public AdministradorProfile()
        {
            CreateMap<Administrador, AdministradorDTO>();
        }
    }
}
