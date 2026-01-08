using Application.DTOs.Emprendimiento;
using Application.DTOs.Estudio;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExAlumno
{
    public class ExAlumnoDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; } = string.Empty;
        public int AnioEgreso { get; set; }
        
        public ICollection<EstudioDTO> Estudios { get; set; } = new List<EstudioDTO>();
    }
}
