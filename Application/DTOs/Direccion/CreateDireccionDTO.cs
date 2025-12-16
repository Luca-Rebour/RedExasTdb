using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Direccion
{
    public class CreateDireccionDTO
    {
        public string Calle { get; set; }
        public string Esquina { get; set; }
        public string NumeroPuerta { get; set; }
        public string Barrio { get; set; }
        public string Departamento { get; set; }

        public void Validate()
        {

        }
    }
}
