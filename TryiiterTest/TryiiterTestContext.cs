using tryiiter.Models;
using tryiiter.Repository;

public class RepositoryTest
{
    [Fact]
    public void ShouldReturnAllPosts()
    {
        TryiiterContext context = Helpers.GetContextInstanceForTests("ShouldReturnAllPosts");
        PostRepository repository = new PostRepository(context);

        var posts = repository.GetPosts().ToList();
        
        posts.Count().Should().Be(2);
        posts[0].Content.Should().Be("content1");
        posts[0].CreatedAt.Should().BeSameDateAs(DateTime.Now);
        posts[0].UpdatedAt.Should().BeSameDateAs(DateTime.Now);
        posts[0].Image.Should().Be("image1");
        posts[0].User.Should().BeNull();
        posts[0].PostCategories.Should().BeNull();
        posts[0].UserId.Should().Be(1);
    }
}