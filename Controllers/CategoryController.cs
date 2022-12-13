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
    public IActionResult GetCategories()
    {
        return Ok(_repository.GetCategories());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        return Ok(_repository.GetCategoryById(id));
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult AddCategory([FromBody] Category categoryName)
    {
        _repository.AddCategory(categoryName.Name);
        return Ok(new { message = "Adicionado com sucesso!" });
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateUserStatus([FromBody] string newCategoryName, int id)
    {
        _repository.UpdateCategory(id, newCategoryName);
        return Ok(new { message = "Atualizado com sucesso!" });
    }
}