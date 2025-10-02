using Application.DTOs.Empresa;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Empresas
{
    public interface ICreateEmpresa
    {
        Task<EmpresaDTO> ExecuteAsync(CreateEmpresaDTO createEmpresaDTO);
    }
}
