using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Respuesta
    {
        public Guid Id { get; private set; }
        public string Texto { get; private set; } = string.Empty;


        public Guid PublicacionId { get; private set; }
        public Publicacion? Publicacion { get; private set; }


        public Guid ExAlumnoId { get; private set; }
        public ExAlumno? ExAlumno { get; private set; }

        public void SetExAlumnoId(Guid exAlumnoId)
        {
            ExAlumnoId = exAlumnoId;
        }
    }
}
