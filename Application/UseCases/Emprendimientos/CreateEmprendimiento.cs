using Application.DTOs.Emprendimiento;
using Application.DTOs.ExAlumnos;
using Application.DTOs.Portfolio;
using Application.DTOs.Servicio;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.Emprendimientos;
using Application.Interfaces.UseCases.Portfolios;
using Application.Interfaces.UseCases.Servicios;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Emprendimientos
{
    public class CreateEmprendimiento : ICreateEmprendimiento
    {
        private readonly IEmprendimientoRepository _emprendimientoRepository;
        private readonly IMapper _mapper;
        private readonly ICreatePortfolio _createPortfolio;
        private readonly ICreateServicio _createServicio;

        public CreateEmprendimiento(IEmprendimientoRepository emprendimientoRepository, IMapper mapper, ICreatePortfolio createPortfolio, ICreateServicio createServicio)
        {
            _emprendimientoRepository = emprendimientoRepository;
            _mapper = mapper;
            _createPortfolio = createPortfolio;
            _createServicio = createServicio;
        }

        public async Task<EmprendimientoDTO> ExecuteAsync(CreateEmprendimientoDTO emprendimientoDTO, Guid userId)
        {

            emprendimientoDTO.Validate();
            Emprendimiento emprendimiento = _mapper.Map<Emprendimiento>(emprendimientoDTO);
            emprendimiento.Disponibilidad.setEmprendimientoId(emprendimiento.Id);

            emprendimiento.setExAlumnoId(userId);

            foreach (DisponibilidadDia disponibilidadDia in emprendimiento.Disponibilidad.Dias)
            {
                disponibilidadDia.setDispoinibilidadId(emprendimiento.Disponibilidad.Id);
            }



            emprendimiento = await _emprendimientoRepository.CreateEmprendimientoAsync(emprendimiento);
            EmprendimientoDTO emprendimientoCreadoDTO = _mapper.Map<EmprendimientoDTO>(emprendimiento);

            foreach (CreatePortfolioDTO p in emprendimientoDTO.PortfoliosDTO)
            {
                p.EmprendimientoId = emprendimientoCreadoDTO.Id;
                emprendimientoCreadoDTO.Portfolios.Add(_mapper.Map<PortfolioDTO>(await _createPortfolio.ExecuteAsync(p)));
            }
            
            foreach (CreateServicioDTO s in emprendimientoDTO.ServiciosDTO)
            {
                s.EmprendimientoId = emprendimientoCreadoDTO.Id;
                emprendimientoCreadoDTO.Servicios.Add(_mapper.Map<ServicioDTO>(await _createServicio.ExecuteAsync(s)));
            }

            return emprendimientoCreadoDTO;
        }
    }
}
