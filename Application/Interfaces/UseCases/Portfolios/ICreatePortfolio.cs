using Application.DTOs.Emprendimiento;
using Application.DTOs.Portfolio;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Portfolios
{
    public interface ICreatePortfolio
    {
        Task<Portfolio> ExecuteAsync(CreatePortfolioDTO portfolioDTO);
    }
}
