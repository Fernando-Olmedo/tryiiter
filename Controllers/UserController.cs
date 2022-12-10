using Microsoft.AspNetCore.Mvc;
using tryiiter.Repository;
using tryiiter.Models;

namespace tryiiter.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly UserRepository _repository;
    private IActionResult? _result;
    public UserController(UserRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public IActionResult GetUser()
    {
        Ok(_repository.GetUsers());
        return _result!;
    }
    [HttpGet("{id}")]
    public IActionResult GetUserById(long id)
    {
        Ok(_repository.GetUserById(id));
        return _result!;
    }
    [HttpPost]
    public IActionResult AddUser([FromBody] IUser user)
    {
        _repository.AddUser(user);
        return _result!;
    }
    [HttpPatch("{id}")]
    public IActionResult UpdateModule([FromBody] string module, long id)
    {
        _repository.UpdateUserModule(id, module);
        return _result!;
    }
    [HttpPatch("{id}")]
    public IActionResult UpdateUserStatus([FromBody] string status, long id)
    {
        _repository.UpdateUserStatus(id, status);
        return _result!;
    }
}
