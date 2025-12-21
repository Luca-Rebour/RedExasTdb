using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Publicacion
{
    public class CreatePublicacionDTO
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }

        [JsonIgnore]
        public Guid ExAlumnoId { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
            {
                throw new ArgumentOutOfRangeException(nameof(Titulo), "El titulo de la publicacion es obligatorio");
            }

            if (string.IsNullOrWhiteSpace(Texto))
            {
                throw new ArgumentOutOfRangeException(nameof(Texto), "El texto de la publicacion es obligatorio");
            }
        }
    }
}
