using Application.DTOs.ExAlumno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.ExAlumnos
{
    public interface IGetExAlumnoById
    {
        Task<ExAlumnoDetailDTO> ExecuteAsync(Guid exAlumnoId);
    }
}
