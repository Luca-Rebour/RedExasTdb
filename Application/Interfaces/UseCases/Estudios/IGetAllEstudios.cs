using Application.DTOs.Estudio;
using Application.DTOs.ExAlumno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Estudios
{
    public interface IGetAllEstudios
    {
        Task<List<EstudioDTO>> ExecuteAsync();
    }
}
