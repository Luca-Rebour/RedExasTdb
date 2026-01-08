using Application.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly ILogger<PasswordService> _logger;
        public PasswordService(ILogger<PasswordService> logger)
        {
            _logger = logger;
        }

        public string HashPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        public bool VerifyPassword(string hashedPassword, string plainPassword)
        {

            var sw = Stopwatch.StartNew();
            bool ret = BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
            sw.Stop();
            _logger.LogInformation("LOGIN BCrypt.Verify: {ms} ms", sw.ElapsedMilliseconds);
            return ret;
        }
    }
}
