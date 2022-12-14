using tryiiter.Models;

namespace tryiiter.Repository;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> GetCategoryById(int id);
    Task<string> AddCategory(string categoryName);
    Task<string> UpdateCategory(int id, string newCategoryName);
}