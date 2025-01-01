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

        [HttpGet("user/{userId:int}")]
        public async Task<IActionResult> GetInvestmentsByUser(int userId)
        {
            var investments = await _repository.FindAsync(i => i.UserID == userId);
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

        [HttpDelete("{userId:int}/{investId:int}")]
        public async Task<IActionResult> DeleteInvestment(int userId, int investId)
        {
            var investment = await _repository.FindAsync(i => i.UserID == userId && i.InvestID == investId);
            if (investment == null || !investment.Any())
            {
                return NotFound("Investment not found.");
            }

            _repository.Delete(investment.First());
            await _repository.SaveAsync();

            return Ok(new { message = "Investment deleted successfully", investId });
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