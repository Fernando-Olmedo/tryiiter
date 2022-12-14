using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<IActionResult> GetUser()
    {
        return Ok(_repository.GetUsers());
    }
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetUserById(long id)
    {
        var user = await _repository.GetUserById(id);
        var result = new {
            Name = user.Name,
            Email = user.Email,
            Module = user.Module,
            Status = user.Status
        };
        return Ok(result);
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> AddUser([FromBody] User _user)
    {
        var result = await _repository.AddUser(_user);
        return Created("ok", new { message = result });
    }
    [HttpPatch("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateModule([FromBody] string module, long id)
    {
        _repository.UpdateUserModule(id, module);
        return Ok(new { message = "Atualizado com sucesso!" });
    }
    [HttpPatch("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateUserStatus([FromBody] string status, long id)
    {
        _repository.UpdateUserStatus(id, status);
        return Ok(new { message = "Atualizado com sucesso!" });
    }
}