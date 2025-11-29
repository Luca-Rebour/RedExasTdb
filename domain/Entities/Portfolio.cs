using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Portfolio
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public DateOnly Fecha { get; private set; }
        public string Imagen { get; private set; } = string.Empty;
        public Guid EmprendimientoId { get; private set; }
        public Emprendimiento? Emprendimiento { get; private set; }
    }
}
