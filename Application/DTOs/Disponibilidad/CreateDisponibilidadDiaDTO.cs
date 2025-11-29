using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Disponibilidad
{
    public class CreateDisponibilidadDiaDTO
    {
        public Guid DisponibilidadId { get; set; }
        public DiaSemana Dia { get; set; }
    }
}
