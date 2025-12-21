using Application.DTOs.ExAlumnos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Publicacion
{
    public class PublicacionDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public ExAlumnoDTO ExAlumno { get; set; }
    }
}
