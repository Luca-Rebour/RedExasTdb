using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Emprendimiento
{
    public class CreateEmprendimientoDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;

        public void validate()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new ArgumentOutOfRangeException(nameof(Nombre), "El nombre es obligatorio");
            }

            if (String.IsNullOrEmpty(Descripcion))
            {
                throw new ArgumentOutOfRangeException(nameof(Descripcion), "La descripción es obligatoria");
            }

            if (String.IsNullOrEmpty(Ubicacion))
            {
                throw new ArgumentOutOfRangeException(nameof(Ubicacion), "La ubicación es obligatoria");
            }

            if (Descripcion.Length < 20)
            {
                throw new ArgumentOutOfRangeException(nameof(Descripcion), "La descripción tiene que tener mas de 20 caracteres");
            }
        }
    }
}
