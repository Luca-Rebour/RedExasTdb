using Application.DTOs.Emprendimiento;
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
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<CreateEmpresaDTO, Empresa>();
            CreateMap<Empresa, EmpresaDTO>();
        }
    }
}
