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
        public string Titulo { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public DateOnly Fecha { get; private set; }
        public string? ImagenUrl { get; private set; }
    }
}
