using tryiiter.Models;

namespace tryiiter.Repository;

public class UserRepository : IUserRepository
{
    private readonly TryiiterContext _context;

    public UserRepository(TryiiterContext context)
    {
        _context = context;
    }
    public IEnumerable<Post> GetUsers()
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
            });
    }
    public void AddUser(IUser user)
    {
        User newUser = new User
        {
            UserId = user.UserId,
            Name = user.Name,
            Email = user.Email,
            Module = user.Module,
            Status = user.Status,
            Password = user.Password
        };
        
        _context.Users.Add(newUser);
        _context.SaveChanges();
    }
}