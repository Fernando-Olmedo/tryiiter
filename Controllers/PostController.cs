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
    public IActionResult Get()
    {
        return Ok(_repository.GetPosts());
    }
}