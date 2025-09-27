using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OfertaLaboral
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public string Modalidad { get; private set; } = string.Empty;
        public string? Direccion { get; private set; } // NULL permitido
        public decimal? Salario { get; private set; } // NULL permitido


        public Guid CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }


        public Guid EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
    }
}
