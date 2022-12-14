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
    public async Task<IActionResult> Get()
    {
        var result = await _repository.GetPosts();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _repository.GetPostById(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] PostInsert post)
    {
        var response = await _repository.AddPost(post);
        return Created("", response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] PostUpdate post, long id)
    {
        var response = await _repository.UpdatePost(post, id);
        if (response.Contains("atualizado"))
        {
            return Ok(new { message = response });
        }

        return NotFound(new { message = response });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var response = await _repository.DeletePost(id);

        if (response.Contains("Removido"))
        {
            return Ok(new { message = response });
        }

        return NotFound(new { message = response });
    }
}