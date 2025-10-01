using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AuthResult
{
    public class SignInResultDTO
    {
        public bool Success { get; private set; }
        public string? Error { get; private set; }
        public string? Token { get; private set; }

        private SignInResultDTO(bool success, string? token = null, string? error = null)
        {
            Success = success;
            Token = token;
            Error = error;
        }

        public static SignInResultDTO SuccessResult(string token) =>
            new SignInResultDTO(true, token);

        public static SignInResultDTO Fail(string errorMessage) =>
            new SignInResultDTO(false, null, errorMessage);
    }
}
