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
    public async Task<IActionResult> GetUser()
    {
        return Ok(_repository.GetUsers());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(long id)
    {
        var user = await _repository.GetUserById(id);
        var result = {
            Name = user.Name,
            Email = user.Email,
            Module = user.Module,
            Status = user.Status
        };
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        _repository.AddUser(user);
        var result = {
            Name = user.Name,
            Email = user.Email,
            Module = user.Module,
            Status = user.Status
        };
        return Created("ok", result);
    }
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateModule([FromBody] string module, long id)
    {
        _repository.UpdateUserModule(id, module);
        return Ok(new { message = "Atualizado com sucesso!" });
    }
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUserStatus([FromBody] string status, long id)
    {
        _repository.UpdateUserStatus(id, status);
        return Ok(new { message = "Atualizado com sucesso!" });
    }
}
