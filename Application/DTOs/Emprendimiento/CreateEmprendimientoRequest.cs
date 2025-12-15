using Application.DTOs.Disponibilidad;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Emprendimiento
{
    public class CreateEmprendimientoRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public Guid? EstudioId { get; set; }
        public CreateDisponibilidadDTO? Disponibilidad { get; set; }
        public IFormFile? Logo { get; set; }
    }

}
