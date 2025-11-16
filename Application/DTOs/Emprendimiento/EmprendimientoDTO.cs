using Application.DTOs.ExAlumnos;
using Application.DTOs.Servicio;
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
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public List<ServicioDTO> servicios { get; set; } = new List<ServicioDTO>();
        public ExAlumnoDTO? ExAlumno { get; set; }
    }
}
