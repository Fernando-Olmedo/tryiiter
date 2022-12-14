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

    public async Task<IEnumerable<PostDTO>> GetPosts()
    {
        var posts = _context.Posts
            .Select(x => new PostDTO
            {
                Id = x.PostId,
                Content = x.Content,
                UserId = x.UserId,
                Image = x.Image,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            });
        
        var result = await posts.ToListAsync();
        return result;
    }

    public async Task<PostDTO> AddPost(PostInsert post)
    {
        Post newPost = new Post
        {
            Content = post.Content,
            UserId = post.UserId,
            Image = post.Image,
            CreatedAt = DateTime.Now
        };

        await _context.Posts.AddAsync(newPost);
        await _context.SaveChangesAsync();

        List<PostCategory> postCategoriesList = new List<PostCategory>();

        foreach (var t in post.CategoryIds)
        {
            postCategoriesList.Add(new PostCategory
            {
                PostId = newPost.PostId,
                CategoryId = t,
            });
        }

        await _context.PostCategories.BulkInsertAsync(postCategoriesList);
        await _context.BulkSaveChangesAsync();

        var response = await _context.Posts
            .Where(x => x.PostId == newPost.PostId)
            .Select(x => new PostDTO
            {
                Id = x.PostId,
                Content = x.Content,
                UserId = x.UserId,
                Image = x.Image,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToListAsync();

        return response[0];
    }

    public async Task<PostDTO> GetPostById(long id)
    {
        var post = await _context.Posts
            .Where(p => p.PostId == id)
            .Select(x => new PostDTO
            {
                Id = x.PostId,
                Content = x.Content,
                UserId = x.UserId,
                Image = x.Image,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).ToListAsync();
        return post[0];
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