using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tryiiter.Models;
using tryiiter.Repository;

namespace tryiiter.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoryController : Controller
{
    private readonly CategoryRepository _repository;

    public CategoryController(CategoryRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    [Route("Categories")]
    public async Task<IActionResult> GetCategories()
    {
        var result = await _repository.GetCategories();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        return Ok(_repository.GetCategoryById(id));
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddCategory([FromBody] Category categoryName)
    {
        await _repository.AddCategory(categoryName.Name);
        return Ok(new { message = "Adicionado com sucesso!" });
    }

    [HttpPatch("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateUserStatus([FromBody] string newCategoryName, int id)
    {
        await _repository.UpdateCategory(id, newCategoryName);
        return Ok(new { message = "Atualizado com sucesso!" });
    }
}