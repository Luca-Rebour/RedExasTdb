using Application.DTOs.Disponibilidad;
using Domain.Entities;
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
        public string Departamento { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public Guid? EstudioId { get; set; }
        public CreateDisponibilidadDTO Disponibilidad { get; set; }

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

            if (String.IsNullOrEmpty(Departamento))
            {
                throw new ArgumentOutOfRangeException(nameof(Descripcion), "El departamento es obligatorio");
            }

            if (String.IsNullOrEmpty(Direccion))
            {
                throw new ArgumentOutOfRangeException(nameof(Direccion), "La ubicación es obligatoria");
            }

            if (Descripcion.Length < 20)
            {
                throw new ArgumentOutOfRangeException(nameof(Descripcion), "La descripción tiene que tener mas de 20 caracteres");
            }
        }
    }
}
