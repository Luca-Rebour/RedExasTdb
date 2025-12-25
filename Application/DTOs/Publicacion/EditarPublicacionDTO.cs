using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Publicacion
{
    public class EditarPublicacionDTO
    {
        public string? Titulo { get; set; }
        public string? Texto { get; set; }

        public void Validate()
        {
            if (Titulo is not null && string.IsNullOrWhiteSpace(Titulo)) 
            { 
                throw new ValidationException("El título no puede estar vacío");
            }
                

            if (Texto is not null && string.IsNullOrWhiteSpace(Texto))
            { 
                throw new ValidationException("El contenido no puede estar vacío");
            }
                
        }
    }
}
