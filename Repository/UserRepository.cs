using tryiiter.Models;
namespace tryiiter.Repository;
public class UserRepository : IUserRepository
{
    private readonly TryiiterContext _context;
    public UserRepository(TryiiterContext context)
    {
        _context = context;
    }
    
    public User Get(string email, string password)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Email == email && u.Password == password);
        return user;
    }
    
    public async Task<IEnumerable<User>> GetUsers()
    {
        return _context.Users.ToList();
    }
    public async Task<User> GetUserById(long id)
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
    public async Task<string> AddUser(User user)
    {
        User newUser = new User
        {
            Name = user.Name,
            Email = user.Email,
            Module = user.Module,
            Status = user.Status,
            Password = user.Password
        };
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
        return "Usuário adicionado com sucesso!";
    }
    public async Task<string> UpdateUserModule(long id, string module)
    {
        var _user = await _context.Users.FindAsync(id);
        if (_user != null)
        {
            _user.Module = module;
            _context.SaveChanges();
            return "Usuário atualizado com sucesso!";
        }

        return "Não foi possível realizar a operação";
    }
    public async Task<string> UpdateUserStatus(long id, string status)
    {
        var _user = await _context.Users.FindAsync(id);
        if (_user != null)
        {
            _user.Status = status;
            await _context.SaveChangesAsync();
            return "Removido com sucesso!";
        }
        return "Não foi possível realizar a operação";
    }
}