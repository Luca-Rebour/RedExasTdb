using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty; // UNIQUE

    }
}
