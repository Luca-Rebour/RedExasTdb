using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Emprendimiento
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nombre { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public string Imagen { get; private set; } = string.Empty;

        // EL ESTUDIO VENDRIA A SER UNA CATEGORIA DEL EMPRENDIMIENTO, PUEDE SER INFORMATICA, MECANICA AUTOMOTRIZ, 
        // MECANICA INDUSTRIAL, ADMINISTRACION, DEPORTE, DISENO GRAFICO, CARPINTERIA
        public Guid EstudioId { get; private set; }
        public Estudio? Estudio { get; private set; }  
        public Disponibilidad Disponibilidad { get; private set; }

        public Guid ExAlumnoId { get; private set; }
        public ExAlumno? ExAlumno { get; private set; }

        public IEnumerable<Servicio> servicios { get; private set; } = new List<Servicio>();
        public Guid DireccionId { get; private set; }
        public Direccion Direccion { get; private set; }

        public void setExAlumnoId(Guid exAlumnoId)
        {
            ExAlumnoId = exAlumnoId;
        }

    }
}
