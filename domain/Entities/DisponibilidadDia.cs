using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DisponibilidadDia
    {
        public Guid Id { get; private set; }
        public Guid DisponibilidadId { get; private set; }
        public Disponibilidad? Disponibilidad { get; private set; }

        public DiaSemana Dia { get; private set; }

        public void setDispoinibilidadId(Guid disponibilidadId)
        {
            DisponibilidadId = disponibilidadId;
        }
    }

}
