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
    public class ExAlumnoProfile : Profile
    {
        public ExAlumnoProfile()
        {
            CreateMap<CreateExAlumnoDTO, ExAlumno>();
            CreateMap<ExAlumno, ExAlumnoDTO>();
        }   
    }
}
