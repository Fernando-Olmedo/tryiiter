using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tryiiter.Models;
using tryiiter.Repository;

namespace tryiiter.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : Controller
{
    private readonly PostRepository _repository;

    public PostController(PostRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
        return Ok(_repository.GetPosts());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {
        return Ok(_repository.GetPostById(id));
    }

    [HttpPost]
    public IActionResult Add([FromBody] PostInsert post)
    {
        _repository.AddPost(post);
        return Created("", post);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromBody] PostInsert post, long id)
    {
        _repository.UpdatePost(post, id);
        return Ok(new { message = "Atualizado com sucesso!" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _repository.DeletePost(id);
        return Ok(new { message = "Removido com sucesso!" });
    }
}