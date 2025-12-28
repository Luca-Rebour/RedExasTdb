using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Portfolio
{
    public class PortfolioDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; }
        public string? ImagenUrl { get; set; }
    }
}
