using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Evento
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public string Ubicacion { get; private set; } = string.Empty;
        public DateTime Fecha { get; private set; }


        public Guid AdministradorId { get; private set; }
        public Administrador? Administrador { get; private set; }
    }
}
