using Application.DTOs.ExAlumno;
using Application.DTOs.ExAlumno;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.ExAlumnos;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ExAlumnos
{
    public class GetExAlumnoById : IGetExAlumnoById
    {
        private readonly IExAlumnoRepository _exAlumnoRepository;
        private readonly IMapper _mapper;

        public GetExAlumnoById(IExAlumnoRepository exAlumnoRepository, IMapper mapper)
        {
            _exAlumnoRepository = exAlumnoRepository;
            _mapper = mapper;
        }
        public async Task<ExAlumnoDetailDTO> ExecuteAsync(Guid exAlumnoId)
        {
            ExAlumnoDetailDTO exAlumnoDTO = _mapper.Map<ExAlumnoDetailDTO>(await _exAlumnoRepository.GetExAlumnoById(exAlumnoId));
            if (exAlumnoDTO == null)
            {
                throw new NotFoundException("Ex alumno", exAlumnoId);
            }
            return exAlumnoDTO;
        }
    }
}
