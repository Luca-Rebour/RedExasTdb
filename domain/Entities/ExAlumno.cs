using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExAlumno : Usuario
    {
        public string Apellido { get; private set; } = string.Empty;
        public int AnioEgreso { get; private set; }
        public Guid DireccionId { get; private set; }
        public Direccion Direccion { get; private set; }
        public ICollection<Estudio> Estudios { get; private set; } = new List<Estudio>();
        public ICollection<Emprendimiento> Emprendimientos { get; private set; } = new List<Emprendimiento>();

    }
}
