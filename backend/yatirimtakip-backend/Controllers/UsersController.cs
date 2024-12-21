using Microsoft.AspNetCore.Mvc;
using yatirimtakip_backend.Models;
using yatirimtakip_backend.Repositories;

namespace yatirimtakip_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> _repository;

        public UsersController(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.GetAllAsync();
            return Ok(users);
        }
    }
}
