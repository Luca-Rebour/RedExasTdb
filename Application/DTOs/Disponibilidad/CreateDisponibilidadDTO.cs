using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Disponibilidad
{
    public class CreateDisponibilidadDTO
    {
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public ICollection<CreateDisponibilidadDiaDTO> Dias { get; set; } = new List<CreateDisponibilidadDiaDTO>();
    }
}
