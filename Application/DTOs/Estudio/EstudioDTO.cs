using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Estudio
{
    public class EstudioDTO
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
    }
}
