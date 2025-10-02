using System;
using System.Linq;
using System.Net.Mail;

namespace Application.DTOs.Empresa
{
    public class CreateEmpresaDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

        public void Validate()
        {
            // Normalizar
            Nombre = (Nombre ?? string.Empty).Trim();
            Email = (Email ?? string.Empty).Trim();
            Contrasena = (Contrasena ?? string.Empty).Trim();
            Telefono = (Telefono ?? string.Empty).Trim();
            Direccion = (Direccion ?? string.Empty).Trim();

            // Nombre
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new ArgumentNullException(nameof(Nombre), "El nombre es obligatorio.");
            if (Nombre.Length > 100)
                throw new ArgumentOutOfRangeException(nameof(Nombre), "El nombre no puede superar 100 caracteres.");
            if (Nombre.Length < 2)
                throw new ArgumentOutOfRangeException(nameof(Nombre), "El nombre debe tener al menos 2 caracteres.");

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

            // Teléfono
            if (string.IsNullOrWhiteSpace(Telefono))
                throw new ArgumentNullException(nameof(Telefono), "El teléfono es obligatorio.");
            if (Telefono.Length > 20)
                throw new ArgumentOutOfRangeException(nameof(Telefono), "El teléfono no puede superar 20 caracteres.");
            if (!Telefono.All(char.IsDigit))
                throw new ArgumentException("El teléfono solo puede contener números.", nameof(Telefono));

            // Dirección
            if (string.IsNullOrWhiteSpace(Direccion))
                throw new ArgumentNullException(nameof(Direccion), "La dirección es obligatoria.");
            if (Direccion.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(Direccion), "La dirección no puede superar 255 caracteres.");
            if (Direccion.Length < 5)
                throw new ArgumentOutOfRangeException(nameof(Direccion), "La dirección debe tener al menos 5 caracteres.");
        }
    }
}
