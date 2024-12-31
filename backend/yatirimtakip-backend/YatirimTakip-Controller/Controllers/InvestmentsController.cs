using Microsoft.AspNetCore.Mvc;
using yatirimtakip_backend.DTOs;
using yatirimtakip_backend.Models;
using yatirimtakip_backend.Repositories;

namespace yatirimtakip_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly IGenericRepository<Investment> _repository;

        public InvestmentsController(IGenericRepository<Investment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvestments()
        {
            var investments = await _repository.GetAllAsync();
            var investmentDtos = investments.Select(i => new InvestmentDto
            {
                InvestID = i.InvestID,
                UserID = i.UserID,
                StockID = i.StockID,
                UnitPrice = i.UnitPrice,
                UnitAmount = i.UnitAmount
            }).ToList();

            return Ok(investmentDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvestment([FromBody] CreateInvestmentDto createInvestmentDto)
        {
            var investment = new Investment
            {
                UserID = createInvestmentDto.UserID,
                StockID = createInvestmentDto.StockID,
                UnitPrice = createInvestmentDto.UnitPrice,
                UnitAmount = createInvestmentDto.UnitAmount
            };

            await _repository.AddAsync(investment);
            await _repository.SaveAsync();

            return CreatedAtAction(nameof(GetAllInvestments), new { id = investment.InvestID }, investment);
        }
    }
}