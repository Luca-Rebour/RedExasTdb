using Application.DTOs.Emprendimiento;
using Application.DTOs.Estudio;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class EstudioProfile : Profile
    {

        public EstudioProfile()
        {
            CreateMap<Estudio, EstudioDTO>();
            CreateMap<EstudioDTO, Estudio>();
        }
    }
}
