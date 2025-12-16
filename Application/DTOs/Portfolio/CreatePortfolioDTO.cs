using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.DTOs.Portfolio
{
    public class CreatePortfolioDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; }
        public IFormFile? Imagen { get; set; }
        public string? ImagenUrl { get; set; }
        public Guid? EmprendimientoId { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
            {
                throw new ArgumentOutOfRangeException(nameof(Titulo), "El titulo es obligatorio");
            }

            if (string.IsNullOrWhiteSpace(Descripcion))
            {
                throw new ArgumentOutOfRangeException(nameof(Descripcion), "La descripción es obligatoria");
            }
        }
    }
}
