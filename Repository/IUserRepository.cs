using tryiiter.Models;

namespace tryiiter.Repository;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUserById(long id);
    Task<string> AddUser(User user);
    Task<string> UpdateUserModule(long id, string module);
    Task<string> UpdateUserStatus(long id, string status);
}