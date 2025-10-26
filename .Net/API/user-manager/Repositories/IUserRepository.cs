using user_manager.Models;

namespace user_manager.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers(int[] ids = null);
    User? GetUserById(int id);
    void AddUser(User user);
    void DeleteUser(int id);
    void UpdateUser(User user);
}