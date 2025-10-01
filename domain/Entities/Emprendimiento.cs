using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Emprendimiento
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public string Ubicacion { get; private set; } = string.Empty;


        public Guid ExAlumnoId { get; private set; }
        public ExAlumno? ExAlumno { get; private set; }

        public void setExAlumnoId(Guid exAlumnoId)
        {
            ExAlumnoId = exAlumnoId;
        }

    }
}
