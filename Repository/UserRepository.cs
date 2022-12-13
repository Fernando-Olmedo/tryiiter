using tryiiter.Models;

namespace tryiiter.Repository;

public class UserRepository : IUserRepository
{
    private readonly TryiiterContext _context;

    public UserRepository(TryiiterContext context)
    {
        _context = context;
    }
    public IEnumerable<User> GetUsers()
    {
        return _context.Users.ToList();
    }
    public User GetUserById(long id)
    {
        return _context.Users
            .Where(u => u.UserId == id)
            .Select(x => new User
            {
                UserId = x.UserId,
                Name = x.Name,
                Email = x.Email,
                Module = x.Module,
                Status = x.Status
            }).First();
    }
    public void AddUser(User user)
    {
        User newUser = new User
        {
            Name = user.Name,
            Email = user.Email,
            Module = user.Module,
            Status = user.Status,
            Password = user.Password
        };
        
        _context.Users.Add(newUser);
        _context.SaveChanges();
    }
    public void UpdateUserModule(long id, string module)
    {
        var _user = _context.Users.Find(id);
        if (_user != null)
        {
            _user.Module = module;
            _context.SaveChanges();
        }
    }

    public void UpdateUserStatus(long id, string status)
    {
        var _user = _context.Users.Find(id);
        if (_user != null)
        {
            _user.Status = status;
            _context.SaveChanges();
        }
    }
}