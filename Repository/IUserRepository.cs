using tryiiter.Models;

namespace tryiiter.Repository;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();
    User GetUserById(long id);
    void AddUser(User user);
    void UpdateUserModule(long id, string module);
    void UpdateUserStatus(long id, string status);
}