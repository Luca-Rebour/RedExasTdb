using Application.DTOs.ExAlumno;
using Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AuthResult
{
    public class SignInResultDTO
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }
        public object Details { get; set; }

        private SignInResultDTO(bool success, string? token = null, string? error = null, object? details = null)
        {
            Success = success;
            Token = token;
            Error = error;
            Details = details;
        }

        public static SignInResultDTO SuccessResult(string token, object details) =>
            new SignInResultDTO(true, token, null, details);

        public static SignInResultDTO Fail(string errorMessage) =>
            new SignInResultDTO(false, null, errorMessage);
    }
}
