using Application.DTOs.Emprendimiento;
using Application.DTOs.Publicacion;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class PublicacionProfile : Profile
    {
        public PublicacionProfile()
        {
            CreateMap<CreatePublicacionDTO, Publicacion>();
            CreateMap<Publicacion, PublicacionDTO>();
            CreateMap<PublicacionDTO, Publicacion>();
            CreateMap<EditarPublicacionDTO, Publicacion>()
                .ForAllMembers(opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));

        }

    }
}
