using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Emprendimiento
{
    public class SearchEmprendimientoQuery
    {
        public string? Departamento { get; set; }
        public string? Calle { get; set; }
        public Guid? ExAlumnoId { get; set; }
        public string? NombreDelServicio { get; set; }
        public string? NombreDelEmprendimiento { get; set; }
    }
}
