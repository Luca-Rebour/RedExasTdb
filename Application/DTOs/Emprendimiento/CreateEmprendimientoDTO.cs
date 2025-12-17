using Application.DTOs.Direccion;
using Application.DTOs.Disponibilidad;
using Application.DTOs.Portfolio;
using Application.DTOs.Servicio;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
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
        public Guid? EstudioId { get; set; }
        public CreateDisponibilidadDTO? Disponibilidad { get; set; }
        public CreateDireccionDTO? Direccion { get; set; }
        public IFormFile Logo { get; set; }
        public string? LogoUrl { get; set; }
        public List<CreatePortfolioDTO>? PortfoliosDTO { get; set; }
        public List<CreateServicioDTO>? ServiciosDTO { get; set; }

        public void Validate()
        {

            if (Descripcion.Length < 20)
            {
                throw new ArgumentOutOfRangeException(nameof(Descripcion), "La descripción tiene que tener mas de 20 caracteres");
            }

        }
    }
}
