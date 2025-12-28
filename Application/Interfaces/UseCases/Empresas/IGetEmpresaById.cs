using Application.DTOs.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Empresas
{
    public interface IGetEmpresaById
    {
        Task<EmpresaDTO> ExecuteAsync(Guid empresaId);
    }
}
