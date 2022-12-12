using Microsoft.EntityFrameworkCore;
using tryiiter.Models;
using tryiiter.Repository;

public static class Helpers
{
    public static TryiiterContext GetContextInstanceForTests(string inMemoryDbName)
    {
        var contextOptions = new DbContextOptionsBuilder<TryiiterContext>()
            .UseInMemoryDatabase(inMemoryDbName)
            .Options;
        var context = new TryiiterContext(contextOptions);
        context.Posts.AddRange(
            GetPostsListForTests()
        );
        context.SaveChanges();
        return context;
    }

    public static List<Post> GetPostsListForTests() =>
        new()
        {
            new Post
            {
                CreatedAt = default,
                UpdatedAt = default,
                PostId = 1,
                Content = "content1",
                UserId = 1,
                Image = "image1",
            },
            new Post
            {
                CreatedAt = default,
                UpdatedAt = default,
                PostId = 2,
                Content = "content2",
                UserId = 1,
                Image = "image2",
            }
        };
}