using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Publicacion
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Titulo { get; private set; } = string.Empty;
        public string Texto { get; private set; } = string.Empty;
        public DateTime Fecha { get; private set; } = DateTime.Now;


        public Guid ExAlumnoId { get; private set; }
        public ExAlumno? ExAlumno { get; private set; }

    }
}
