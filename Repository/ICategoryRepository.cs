using tryiiter.Models;

namespace tryiiter.Repository;

public interface ICategoryRepository
{
    IEnumerable<Category> GetCategories();
    Category GetCategoryById(int id);
    void AddCategory(string categoryName);
    void UpdateCategory(int id, string newCategoryName);
}