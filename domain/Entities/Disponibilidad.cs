using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Disponibilidad
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public TimeOnly HoraInicio { get; private set; }
        public TimeOnly HoraFin { get; private set; }
        public Guid EmprendimientoId { get; private set; }
        public Emprendimiento Emprendimiento { get; set; }

        public ICollection<DisponibilidadDia> Dias { get; private set; } = new List<DisponibilidadDia>();

        public void setEmprendimientoId(Guid emprendimientoId)
        {
            EmprendimientoId = emprendimientoId;
        }
    }

}
