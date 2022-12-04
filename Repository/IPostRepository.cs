using tryiiter.Models;

namespace tryiiter.Repository;

public interface IPostRepository
{
    IEnumerable<Post> GetPosts();
    void AddPost(PostInsert post);
}