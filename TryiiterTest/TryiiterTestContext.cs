using tryiiter.Models;
using tryiiter.Repository;

public class RepositoryTest
{
    [Fact]
    public async void ShouldReturnAllPosts()
    {
        TryiiterContext context = Helpers.GetContextInstanceForTests("ShouldReturnAllPosts");
        PostRepository repository = new PostRepository(context);
    
        var posts = await repository.GetPosts();
        var postDtOs = posts.ToList();
        var postsList = postDtOs.ToList();
        postDtOs.Should().NotBeNull();
        postDtOs.Count.Should().Be(2);
        postDtOs[0].Id.Should().Be(1);
        postDtOs[1].Id.Should().Be(2);
    }

    [Fact]
    public async void ShouldReturnPostById()
    {
        TryiiterContext context = Helpers.GetContextInstanceForTests("ShouldReturnPostById");
        PostRepository repository = new PostRepository(context);

        PostDTO post = await repository.GetPostById(1);
        post.Should().NotBeNull();
        post.Content.Should().Be("content1");
        post.Id.Should().Be(1);
        post.Image.Should().Be("image1");
        post.UserId.Should().Be(1);
    }

    [Fact]
    public async void ShouldAddPost()
    {
        TryiiterContext context = Helpers.GetContextInstanceForTests("ShouldAddPost");
        PostRepository repository = new PostRepository(context);

        PostInsert newPost = new PostInsert
        {
            Content = "content3",
            UserId = 1,
            Image = "image3",
            CategoryIds = new int[]{ 1 }
        };
        
        PostDTO addedPost = await repository.AddPost(newPost);
        addedPost.Should().NotBeNull();
        addedPost.Content.Should().Be("content3");
        addedPost.UserId.Should().Be(1);
        addedPost.Image.Should().Be("image3");
        addedPost.Id.Should().Be(3);
        addedPost.CreatedAt.Should().NotBeAfter(DateTime.Now);
        addedPost.UpdatedAt.Should().NotBeAfter(DateTime.Now);

        var post = await repository.GetPostById(addedPost.Id);
        post.Should().NotBeNull();
        post.Should().BeEquivalentTo(addedPost);
    }

    [Fact]
    public async void ShouldUpdatePost()
    {
        TryiiterContext context = Helpers.GetContextInstanceForTests("ShouldUpdatedPost");
        PostRepository repository = new PostRepository(context);

        PostUpdate postUpdate = new PostUpdate
        {
            Content = "novo conteúdo",
            UserId = 1,
            Image = "nova imagem",
            CategoryIds = new int[]
            {
                2
            }
        };
        
        string successUpdatedMessage = await repository.UpdatePost(postUpdate, 2);
        successUpdatedMessage.Should().Be("Post atualizado com sucesso!");

        PostDTO updatedPost = await repository.GetPostById(2);

        updatedPost.Content.Should().Be(postUpdate.Content);
        updatedPost.Id.Should().Be(2);
        updatedPost.Image.Should().Be(postUpdate.Image);
        updatedPost.CreatedAt.Should().NotBeAfter(DateTime.Now);
        updatedPost.UpdatedAt.Should().NotBeAfter(DateTime.Now);
    }

    [Fact]
    public async void ShoudDeletePost()
    {
        TryiiterContext context = Helpers.GetContextInstanceForTests("ShoulDeletePost");
        PostRepository repository = new PostRepository(context);

        string successDeletedMessage = await repository.DeletePost(1);

        successDeletedMessage.Should().Be("Removido com sucesso!");
    }

    [Fact]
    public async void ShoutNotDeletedAnInexistentPost()
    {
        TryiiterContext context = Helpers.GetContextInstanceForTests("ShoutNotDeletedAnInexistentPost");
        PostRepository repository = new PostRepository(context);

        string failDeletedMessage = await repository.DeletePost(99);

        failDeletedMessage.Should().Be("Não foi possível encontrar um Post com este ID.");
    }
}