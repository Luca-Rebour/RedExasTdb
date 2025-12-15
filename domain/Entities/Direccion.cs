using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Direccion
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Calle { get; private set; }
        public string Esquina { get; private set; }
        public string NumeroPuerta { get; private set; }
        public string Barrio { get; private set; }
        public string Departamento { get; private set; }


    }
}
