using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace tryiiter.Models;

public class PostCategory
{
    [ExcludeFromCodeCoverage]
    [Column("post_id")]
    public long PostId { get; set; }
    [Column("category_id")]
    public int CategoryId { get; set; }

    public Post Post { get; set; }
    public Category Category { get; set; }
}