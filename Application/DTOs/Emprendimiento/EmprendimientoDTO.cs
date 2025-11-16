using Application.DTOs.ExAlumnos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Emprendimiento
{
    public class EmprendimientoDTO
    {
        public Guid IdEmprendimiento { get; set; }
        public Guid IdServicio { get; set; }
        public string NombreEmprendimiento { get; set; } = string.Empty;
        public string DescripcionEmprendimiento { get; set; } = string.Empty;
        public string UbicacionEmprendimiento { get; set; } = string.Empty;
        public string NombreServicio { get; set; } = string.Empty;
        public string DescripcionServicio { get; set; } = string.Empty;

        public ExAlumnoDTO? ExAlumno { get; set; }
    }
}
