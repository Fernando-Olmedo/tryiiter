using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            CreatedAt = DateTime.Now
        };

        _context.Posts.Add(newPost);
        _context.SaveChanges();

        List<PostCategory> postCategoriesList = new List<PostCategory>();

        foreach (var t in post.CategoryIds)
        {
            postCategoriesList.Add(new PostCategory
            {
                PostId = newPost.PostId,
                CategoryId = t,
            });
        }

        _context.PostCategories.BulkInsert(postCategoriesList);
        _context.BulkSaveChanges();
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
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                PostCategories = x.PostCategories
            }).First();
    }

    public void UpdatePost(PostInsert post, long id)
    {
        var _post = _context.Posts.Find(id);
        if (_post != null)
        {
            _post.Content = post.Content;
            _post.Image = post.Image;
            _post.UserId = post.UserId;
            _post.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }

    public void DeletePost(long id)
    {
        var post = _context.Posts.Find(id);

        if (post != null)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}