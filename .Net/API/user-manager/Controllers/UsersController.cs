using Microsoft.AspNetCore.Mvc;
using user_manager.Models;
using user_manager.Repositories;

namespace user_manager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        // For demo purposes, get all users (in a real app, you might want pagination)
        var allUserIds = Enumerable.Range(1, 100).ToArray(); // Get all possible IDs
        var users = _userRepository.GetAllUsers(allUserIds);
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            return NotFound($"User with ID {id} not found.");
        }
        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser(CreateUserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        // Generate a new ID (in a real app, this would be handled by the database)
        var existingUsers = _userRepository.GetAllUsers(Enumerable.Range(1, 1000).ToArray());
        var newId = existingUsers.Any() ? existingUsers.Max(u => u.Id) + 1 : 1;

        var newUser = new User
        {
            Id = newId,
            Name = request.Name
        };

        _userRepository.AddUser(newUser);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id}")]
    public ActionResult<User> UpdateUser(int id, UpdateUserRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest("ID in URL does not match ID in request body.");
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        var existingUser = _userRepository.GetUserById(id);
        if (existingUser == null)
        {
            return NotFound($"User with ID {id} not found.");
        }

        var updatedUser = new User
        {
            Id = request.Id,
            Name = request.Name
        };

        _userRepository.UpdateUser(updatedUser);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            return NotFound($"User with ID {id} not found.");
        }

        _userRepository.DeleteUser(id);
        return NoContent();
    }
}

public class CreateUserRequest
{
    public string Name { get; set; } = string.Empty;
}

public class UpdateUserRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}