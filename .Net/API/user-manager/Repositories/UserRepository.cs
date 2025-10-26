using user_manager.Models;

namespace user_manager.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public UserRepository()
    {
        // Initialize with 5 sample users
        _users.AddRange(new[]
        {
            new User { Id = 1, Name = "John Smith" },
            new User { Id = 2, Name = "Sarah Johnson" },
            new User { Id = 3, Name = "Mike Davis" },
            new User { Id = 4, Name = "Lisa Wilson" },
            new User { Id = 5, Name = "David Brown" }
        });
    }

    public IEnumerable<User> GetAllUsers(int[] ids = null)
    {
        if (ids == null || ids.Length == 0)
        {
            return _users;
        }

        return _users.Where(u => ids.Contains(u.Id));
    }

    public User? GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void DeleteUser(int id)
    {
        var user = GetUserById(id);
        if (user != null)
        {
            _users.Remove(user);
        }
    }

    public void UpdateUser(User user)
    {
        var existingUser = GetUserById(user.Id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
        }
    }
}