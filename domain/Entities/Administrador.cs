using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Administrador : Usuario
    {
        public string Apellido { get; private set; } = string.Empty;

    }
}
