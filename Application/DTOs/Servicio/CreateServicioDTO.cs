using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Servicio
{
    public class CreateServicioDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? EmprendimientoId { get; set; }
        public string? Nombre { get; set; } = null;
        public string Descripcion { get; set; } = string.Empty;
        public decimal? Costo { get; set; }
        public string IconName { get; set; }

        public void Validate()
        {

        }
    }
}
