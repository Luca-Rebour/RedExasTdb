using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Repuesta
{
    public class CreateRespuestaDTO
    {
        public Guid PublicacionId { get; set; }
        public string Texto { get; set; }

        public void Validate()
        {

        }
    }
}
