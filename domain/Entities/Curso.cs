
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Curso
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public string Modalidad { get; private set; } = string.Empty;
        public string? Ubicacion { get; private set; } // NULL permitido
        public string Instituto { get; private set; } = string.Empty;


        public Guid AdministradorId { get; private set; }
        public Administrador? Administrador { get; private set; }

        public Guid CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }
    }
}
