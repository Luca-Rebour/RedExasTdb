using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> CreatePortfolio(Portfolio portfolio); // CREA EL PORTFOLIO Y LO GUARDA
        Portfolio AddPortfolio(Portfolio portfolio); // CREA EL PORTFOLIO PERO NO LO GUARDA
    }
}
