using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Servicio
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nombre { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public string IconName { get; private set; } = string.Empty;
        public double? Costo { get; private set; }


        public Guid EmprendimientoId { get; private set; }
        public Emprendimiento? Emprendimiento { get; private set; }
    }
}
