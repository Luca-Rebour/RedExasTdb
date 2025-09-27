using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empresa : Usuario
    {
        public string Telefono { get; private set; } = string.Empty;
        public string Direccion { get; private set; } = string.Empty;

    }
}
