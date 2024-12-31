using Microsoft.AspNetCore.Mvc;
using yatirimtakip_backend.DTOs;
using yatirimtakip_backend.Models;
using yatirimtakip_backend.Repositories;
using yatirimtakip_backend.Data;
using Dapper;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace yatirimtakip_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly IGenericRepository<Investment> _repository;
        private readonly ApplicationDbContext _context;

        public InvestmentsController(IGenericRepository<Investment> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
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
            // Check if there are existing investments for the user
            var existingInvestments = await _repository.FindAsync(i => i.UserID == createInvestmentDto.UserID);

            if (!existingInvestments.Any())
            {
                // Reset the InvestID sequence for the user
                await ResetInvestIDSequence();
            }

            var investment = new Investment
            {
                UserID = createInvestmentDto.UserID,
                StockID = createInvestmentDto.StockID,
                UnitPrice = createInvestmentDto.UnitPrice,
                UnitAmount = createInvestmentDto.UnitAmount,
                Type = createInvestmentDto.Type
            };

            await _repository.AddAsync(investment);
            await _repository.SaveAsync();

            return CreatedAtAction(nameof(GetAllInvestments), new { id = investment.InvestID }, investment);
        }

        private async Task ResetInvestIDSequence()
        {
            var connectionString = _context.Database.GetConnectionString();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sequenceName = await connection.QuerySingleOrDefaultAsync<string>("SELECT pg_get_serial_sequence('\"Investments\"', 'InvestID')");
                if (!string.IsNullOrEmpty(sequenceName))
                {
                    await connection.ExecuteAsync($"ALTER SEQUENCE {sequenceName} RESTART WITH 1");
                }
            }
        }
    }
}