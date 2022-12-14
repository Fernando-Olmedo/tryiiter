
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tryiiter.Models;
using tryiiter.Repository;
using tryiiter.Utils;

namespace tryiiter.Controllers;

[ApiController]
[Route("v1")]
public class LoginController : ControllerBase
{
    public UserRepository _repository;

    public LoginController(UserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<IActionResult> AuthenticateAsync([FromBody] User model)
    {
        var user = _repository.Get(model.Email, model.Password);

        if (user == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

        var token = TokenGenerator.Generate(user);

        user.Password = "";

        return Ok(new
        {
            token = token
        });
    }
    
}