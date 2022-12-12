using Microsoft.AspNetCore.Mvc;
using tryiiter.Repository;
using tryiiter.Models;

namespace tryiiter.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly UserRepository _repository;
    public UserController(UserRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public IActionResult GetUser()
    {
        return Ok(_repository.GetUsers());
    }
    [HttpGet("{id}")]
    public IActionResult GetUserById(long id)
    {
        return Ok(_repository.GetUserById(id));
    }
    [HttpPost]
    public IActionResult AddUser([FromBody] IUser user)
    {
        return Created(_repository.AddUser(user));
    }
    [HttpPatch("{id}")]
    public IActionResult UpdateModule([FromBody] string module, long id)
    {
        return Ok(_repository.UpdateUserModule(id, module));
    }
    [HttpPatch("{id}")]
    public IActionResult UpdateUserStatus([FromBody] string status, long id)
    {
        return Ok(_repository.UpdateUserStatus(id, status));
    }
}
