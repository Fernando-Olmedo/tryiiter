using tryiiter.Models;

namespace tryiiter.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly TryiiterContext _context;

    public CategoryRepository(TryiiterContext context)
    {
        _context = context;
    }

    public void UpdateUserStatus(long id, string status)
    {
        var _user = _context.Users.Find(id);
        if (_user != null)
        {
            _user.Status = status;
            _context.SaveChanges();
        }
    }

    public IEnumerable<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategoryById(int id)
    {
        var category = _context.Categories.Find(id);
        _context.SaveChanges();
        return category;
    }

    public void AddCategory(string categoryName)
    {
        Category newCategory = new Category
        {
            Name = categoryName,
        };
        
        _context.Categories.Add(newCategory);
        _context.SaveChanges();
    }

    public void UpdateCategory(int id, string newCategoryName)
    {
        var _category = _context.Categories.Find(id);
        if (_category != null)
        {
            _category.Name = newCategoryName;
            _context.SaveChanges();
        }
    }
}