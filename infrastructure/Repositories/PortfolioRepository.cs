using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private AppDbContext _context;

        public PortfolioRepository (AppDbContext context)
        {
            _context = context;
        }
        public async Task<Portfolio> CreatePortfolio(Portfolio portfolio)
        {
             _context.Portfolios.Add(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }
    }
}
