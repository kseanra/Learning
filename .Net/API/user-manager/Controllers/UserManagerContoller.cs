using Microsoft.AspNetCore.Mvc;
using user_manager.Models;
using user_manager.Repositories;

namespace user_manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("healthy")]
        public IActionResult Healthy()
        {
            return Ok();
        }

        [HttpGet("users")]
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}