using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace tryiiter.Models;

public class Category : ICategory
{
    [ExcludeFromCodeCoverage]
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    
    [ForeignKey("CategoryId")]
    public ICollection<PostCategory>? PostCategories { get; set; }
}

public class UpdateCategory
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
}