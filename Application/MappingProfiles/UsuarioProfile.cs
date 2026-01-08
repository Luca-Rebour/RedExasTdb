using Application.DTOs.Direccion;
using Application.DTOs.Usuario;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<ExAlumno, UsuarioDTO>();
            CreateMap<Empresa, UsuarioDTO>();
            CreateMap<Administrador, UsuarioDTO>();
        }
    }
}
