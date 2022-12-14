
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
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<IActionResult> AuthenticateAsync([FromBody] User model)
    {
        var user = UserRepository.Get(model.Email, model.Password);

        if (user == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

        var token = TokenGenerator.Generate(user);

        user.Password = "";

        return Ok(new
        {
            user = user,
            token = token
        });
    }
    
}