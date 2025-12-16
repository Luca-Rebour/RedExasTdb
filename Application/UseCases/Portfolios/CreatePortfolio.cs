using Application.DTOs.Portfolio;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Portfolios;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Portfolios
{
    public class CreatePortfolio : ICreatePortfolio
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;
        public CreatePortfolio(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }
        public async Task<Portfolio> ExecuteAsync(CreatePortfolioDTO portfolioDTO)
        {
            portfolioDTO.Validate();
            Portfolio portfolio = _mapper.Map<Portfolio>(portfolioDTO);
            return await _portfolioRepository.CreatePortfolio(portfolio);
        }
    }
}
