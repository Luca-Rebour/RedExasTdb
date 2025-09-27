using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IPasswordService
    {
        string HashPassword(string plainPassword);
        bool VerifyPassword(string hashedPassword, string plainPassword);
    }
}
