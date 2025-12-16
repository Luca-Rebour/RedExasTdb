using Application.DTOs.Disponibilidad;
using Application.DTOs.Estudio;
using Application.DTOs.ExAlumnos;
using Application.DTOs.Portfolio;
using Application.DTOs.Servicio;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Emprendimiento
{
    public class EmprendimientoDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public EstudioDTO? Estudio { get; set; }
        public ICollection<ServicioDTO> Servicios { get; set; } = new List<ServicioDTO>();
        public ICollection<PortfolioDTO> Portfolios { get; set; } = new List<PortfolioDTO>();
        public DisponibilidadDTO Disponibilidad { get; set; }
        public ExAlumnoDTO? ExAlumno { get; set; }
    }
}
