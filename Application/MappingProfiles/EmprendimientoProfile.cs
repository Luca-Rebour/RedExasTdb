using Application.DTOs.Emprendimiento;
using Application.DTOs.ExAlumnos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class EmprendimientoProfile : Profile
    {
        public EmprendimientoProfile()
        {
            CreateMap<CreateEmprendimientoDTO, Emprendimiento>()
                .ForMember(e => e.Imagen, o => o.MapFrom(s => s.LogoUrl));

            CreateMap<Emprendimiento, EmprendimientoDTO>();
        }
    }
}
