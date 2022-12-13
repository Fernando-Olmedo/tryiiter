using System.ComponentModel.DataAnnotations.Schema;

namespace tryiiter.Models;

public class PostCategory
{
    [Column("post_id")]
    public long PostId { get; set; }
    [Column("category_id")]
    public int CategoryId { get; set; }

    public Post Post { get; set; }
    public Category Category { get; set; }
}
