using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExAlumnos
{
    public class CreateExAlumnoDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // UNIQUE
        public string Contrasena { get; set; } = string.Empty;
        public int AnioEgreso { get; set; }

        public void Validate()
        {
            // Normalizar (evita espacios “invisibles”)
            Nombre = (Nombre ?? string.Empty).Trim();
            Apellido = (Apellido ?? string.Empty).Trim();
            Email = (Email ?? string.Empty).Trim();
            Contrasena = (Contrasena ?? string.Empty).Trim();

            // Nombre
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new ArgumentNullException(nameof(Nombre), "El nombre es obligatorio.");
            if (Nombre.Length > 50)
                throw new ArgumentOutOfRangeException(nameof(Nombre), "El nombre no puede superar 50 caracteres.");
            if (Nombre.Length < 2)
                throw new ArgumentOutOfRangeException(nameof(Nombre), "El nombre debe tener al menos 2 caracteres.");

            // Apellido
            if (string.IsNullOrWhiteSpace(Apellido))
                throw new ArgumentNullException(nameof(Apellido), "El apellido es obligatorio.");
            if (Apellido.Length > 50)
                throw new ArgumentOutOfRangeException(nameof(Apellido), "El apellido no puede superar 50 caracteres.");
            if (Apellido.Length < 2)
                throw new ArgumentOutOfRangeException(nameof(Apellido), "El apellido debe tener al menos 2 caracteres.");

            // Email
            if (string.IsNullOrWhiteSpace(Email))
                throw new ArgumentNullException(nameof(Email), "El email es obligatorio.");
            if (Email.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(Email), "El email no puede superar 255 caracteres.");
            try
            {
                _ = new MailAddress(Email); // lanza FormatException si es inválido
            }
            catch (FormatException ex)
            {
                throw new FormatException("El email no tiene un formato válido.", ex);
            }

            // Contraseña
            if (string.IsNullOrWhiteSpace(Contrasena))
                throw new ArgumentNullException(nameof(Contrasena), "La contraseña es obligatoria.");
            if (Contrasena.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(Contrasena), "La contraseña no puede superar 255 caracteres.");
            if (Contrasena.Length < 8)
                throw new ArgumentOutOfRangeException(nameof(Contrasena), "La contraseña debe tener al menos 8 caracteres.");
            // (Opcional) Complejidad mínima:
            // if (!Contrasena.Any(char.IsDigit) || !Contrasena.Any(char.IsUpper) || !Contrasena.Any(char.IsLower))
            //     throw new ValidationException("La contraseña debe incluir mayúscula, minúscula y número.");

            // Año de egreso
            var currentYear = DateTime.UtcNow.Year;
            if (AnioEgreso < 1900 || AnioEgreso > currentYear)
                throw new ArgumentOutOfRangeException(nameof(AnioEgreso),
                    $"El año de egreso debe estar entre 1900 y {currentYear}.");
        }
    

}
}
