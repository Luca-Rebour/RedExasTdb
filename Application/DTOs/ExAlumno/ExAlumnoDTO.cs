using Application.DTOs.Estudio;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExAlumnos
{
    public class ExAlumnoDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; } = string.Empty;
        public int AnioEgreso { get; set; }

        public ICollection<EstudioDTO> Estudios { get; set; } = new List<EstudioDTO>();
        public Guid? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
