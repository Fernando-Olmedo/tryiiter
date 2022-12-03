using tryiiter.Models;

namespace tryiiter.Repository;

public class PostRepository : IPostRepository
{
    private readonly TryiiterContext _context;

    public PostRepository(TryiiterContext context)
    { 
        _context = context;
    }

    public IEnumerable<Post> GetPosts()
    {
        return _context.Posts.ToList();
    }
}