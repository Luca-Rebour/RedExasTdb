using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public string Rol {  get; set; }
        public object Details { get; set; }


        public UsuarioDTO (string rol, object details)
        {
            Rol = rol;
            Details = details;
           
        }
    }
}
