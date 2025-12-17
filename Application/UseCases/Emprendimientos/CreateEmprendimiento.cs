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
        private readonly IEmprendimientoRepository _empRepo;
        private readonly ICreatePortfolio _createPortfolio;
        private readonly ICreateServicio _createServicio;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateEmprendimiento(
            IEmprendimientoRepository empRepo,
            IMapper mapper,
            ICreatePortfolio createPortfolio,
            ICreateServicio createServicio,
            IUnitOfWork uow)
        {
            _empRepo = empRepo;
            _mapper = mapper;
            _createPortfolio = createPortfolio;
            _createServicio = createServicio;
            _uow = uow;
        }

        public async Task<EmprendimientoDTO> ExecuteAsync(CreateEmprendimientoDTO dto, Guid userId)
        {
            dto.Validate();

            await _uow.BeginTransactionAsync();
            try
            {
                Emprendimiento emp = _mapper.Map<Emprendimiento>(dto);
                emp.setExAlumnoId(userId);


                _empRepo.CreateEmprendimiento(emp);

                if (dto.PortfoliosDTO != null)
                {
                    foreach (CreatePortfolioDTO p in dto.PortfoliosDTO)
                    {
                        p.EmprendimientoId = emp.Id;
                        emp.AddPortfolio(_mapper.Map<Portfolio>(p));
                    }
                }

                if (dto.ServiciosDTO != null)
                {
                    foreach (CreateServicioDTO s in dto.ServiciosDTO)
                    {
                        s.EmprendimientoId = emp.Id;
                        emp.AddServicio(_mapper.Map<Servicio>(s));
                    }
                }

                if (emp.Disponibilidad != null)
                {
                    emp.Disponibilidad.setEmprendimientoId(emp.Id);

                    foreach (var dia in emp.Disponibilidad.Dias)
                        dia.setDispoinibilidadId(emp.Disponibilidad.Id);
                }


                await _uow.SaveChangesAsync();  // GUARDA TODOS LOS CAMBIOS REALIZADOS EN ESTE METODO
                await _uow.CommitAsync();

                return _mapper.Map<EmprendimientoDTO>(emp);
            }
            catch
            {
                await _uow.RollbackAsync();
                throw;
            }
        }
    }

}
