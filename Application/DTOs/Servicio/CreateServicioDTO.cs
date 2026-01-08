using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Servicio
{
    public class CreateServicioDTO
    {
        [JsonIgnore]
        public Guid EmprendimientoId { get; set; }
        public string? Nombre { get; set; } = null;
        public string Descripcion { get; set; } = string.Empty;
        public decimal? Costo { get; set; }
        public string IconName { get; set; }

        public void Validate()
        {
            if (EmprendimientoId == null)
            {
                throw new ValidationException("El Id del emprendimiento es obligatorio.");
            }
        }
    }
}
