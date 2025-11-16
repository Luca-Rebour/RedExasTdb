using Application.DTOs.ExAlumnos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.ExAlumnos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ExAlumnos
{
    public class GetAllExAlumnos : IGetAllExAlumnos
    {
        private readonly IExAlumnoRepository _exAlumnoRepository;
        private readonly IMapper _mapper;

        public GetAllExAlumnos(IExAlumnoRepository exAlumnoRepository, IMapper mapper)
        {
            _exAlumnoRepository = exAlumnoRepository;
            _mapper = mapper;
        }
        public async Task<List<ExAlumnoDTO>> ExecuteAsync()
        {
            List<ExAlumno> exAlumnos = await _exAlumnoRepository.GetAllExAlumnosAsync();
            List<ExAlumnoDTO> exAlumnoDTOs = _mapper.Map<List<ExAlumnoDTO>>(exAlumnos);
            return exAlumnoDTOs;
        }
    }
}
