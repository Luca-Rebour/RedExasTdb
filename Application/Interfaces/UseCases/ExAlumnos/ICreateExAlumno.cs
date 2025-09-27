﻿using Application.DTOs.ExAlumnos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.ExAlumnos
{
    public interface ICreateExAlumno
    {
        Task<ExAlumno> ExecuteAsync(CreateExAlumnoDTO exAlumnoDTO);
    }
}
