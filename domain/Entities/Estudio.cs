using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Estudio
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;

        public ICollection<ExAlumno> ExAlumnos { get; private set; } = new List<ExAlumno>();
        public ICollection<OfertaLaboral> OfertasLaborales { get; set; } = new List<OfertaLaboral>();

    }
}
