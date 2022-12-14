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
                CategoryIds = x.PostCategories.Select(y => y.CategoryId).ToList(),
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
                CategoryIds = x.PostCategories.Select(y => y.CategoryId).ToList(),
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
                CategoryIds = x.PostCategories.Select(o => o.CategoryId).ToList(),
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).FirstAsync();
        return post;
    }

    public async Task<string> UpdatePost(PostUpdate post, long id)
    {
        var actualPost = await _context.Posts.FindAsync(id);
        if (actualPost != null)
        {
            actualPost.Content = post.Content ?? actualPost.Content;
            actualPost.Image = post.Image ?? actualPost.Image;
            actualPost.UserId = post.UserId ?? actualPost.UserId;
            actualPost.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return "Post atualizado com sucesso!";
        }

        return "Não foi possível encontrar um post com este ID.";
    }

    public async Task<string> DeletePost(long id)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post != null)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return "Removido com sucesso!";
        }

        return "Não foi possível encontrar um Post com este ID.";
    }
}