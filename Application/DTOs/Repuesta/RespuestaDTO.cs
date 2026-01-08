using Application.DTOs.ExAlumno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Repuesta
{
    public class RespuestaDTO
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public Guid PublicacionId { get; set; }
        public ExAlumnoDTO exAlumno { get; set; }
    }
}
