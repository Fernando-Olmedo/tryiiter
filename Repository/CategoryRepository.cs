using Microsoft.EntityFrameworkCore;
using tryiiter.Models;

namespace tryiiter.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly TryiiterContext _context;

    public CategoryRepository(TryiiterContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        var result = await _context.Categories.ToListAsync();
        return result;
    }

    public async Task<Category> GetCategoryById(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        _context.SaveChanges();
        return category;
    }

    public async Task<string> AddCategory(string categoryName)
    {
        Category newCategory = new Category
        {
            Name = categoryName,
        };
        
        await _context.Categories.AddAsync(newCategory);
        _context.SaveChanges();

        return "Adicionado com sucesso";
    }

    public async Task<string> UpdateCategory(int id, string newCategoryName)
    {
        var _category = await _context.Categories.FindAsync(id);
        if (_category != null)
        {
            _category.Name = newCategoryName;
            await _context.SaveChangesAsync();
        }
        
        return "Atualizado com sucesso";
    }
}