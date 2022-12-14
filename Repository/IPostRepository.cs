using tryiiter.Models;

namespace tryiiter.Repository;

public interface IPostRepository
{
    Task<IEnumerable<PostDTO>> GetPosts();
    Task<PostDTO> AddPost(PostInsert post);
    Task<PostDTO> GetPostById(long id);
    void DeletePost(long id);
}