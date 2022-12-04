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

    public void AddPost(PostInsert post)
    {
        Post newPost = new Post
        {
            Content = post.Content,
            UserId = post.UserId,
            Image = post.Image,
            Updated = post.Updated,
            Published = DateTime.Now
        };

        _context.Posts.Add(newPost);
        _context.SaveChanges();
    }

    public Post GetPostById(long id)
    {
        return _context.Posts
            .Where(p => p.PostId == id)
            .Select(x => new Post
            {
                PostId = x.PostId,
                Content = x.Content,
                UserId = x.UserId,
                Image = x.Image,
                Published = x.Published,
                Updated = x.Updated,
                PostCategories = x.PostCategories
            }).First();
    }
}