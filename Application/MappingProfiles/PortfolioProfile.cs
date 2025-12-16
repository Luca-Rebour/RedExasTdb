using Application.DTOs.Disponibilidad;
using Application.DTOs.Portfolio;
using Application.UseCases.Portfolios;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<Portfolio, PortfolioDTO>()
            .ForMember(d => d.ImagenUrl, o => o.MapFrom(s => s.Imagen));

            CreateMap<PortfolioDTO, Portfolio>()
            .ForMember(d => d.Imagen, o => o.MapFrom(s => s.ImagenUrl));

            CreateMap<CreatePortfolioDTO, Portfolio>()
                .ForMember(d => d.Imagen, o => o.MapFrom(s => s.ImagenUrl));


        }
    }
}
