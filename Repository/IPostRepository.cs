using tryiiter.Models;

namespace tryiiter.Repository;

public interface IPostRepository
{
    Task<IEnumerable<PostDTO>> GetPosts();
    void AddPost(PostInsert post);
    Post GetPostById(long id);
    void DeletePost(long id);
}