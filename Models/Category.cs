using System.ComponentModel.DataAnnotations.Schema;

namespace tryiiter.Models;

public class Category
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    
    [ForeignKey("CategoryId")]
    public ICollection<PostCategory> PostCategories { get; set; }
}