using Application.DTOs.Estudio;
using Application.DTOs.Repuesta;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class RespuestaProfile : Profile
    {
        public RespuestaProfile() 
        {
            CreateMap<CreateRespuestaDTO, Respuesta>();
            CreateMap<Respuesta, RespuestaDTO>();
        }
    }
}
