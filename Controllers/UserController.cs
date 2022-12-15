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
    public async Task<IActionResult> GetUser()
    {
        var response = await _repository.GetUsers();
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(long id)
    {
        var response = await _repository.GetUserById(id); 
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        await _repository.AddUser(user);
        return Created("ok", user);
    }
    [HttpPatch()]
    [Route("module")]
    public async Task<IActionResult> UpdateModule([FromBody] UserModuleUpdate module)
    {
        await _repository.UpdateUserModule(module.UserId, module.Module);
        return Ok(new { message = "Atualizado com sucesso!" });
    }
    [HttpPatch()]
    [Route("status")]
    public async Task<IActionResult> UpdateUserStatus([FromBody] UserStatusUpdate status)
    {
        await _repository.UpdateUserStatus(status.UserId, status.Status);
        return Ok(new { message = "Atualizado com sucesso!" });
    }
}