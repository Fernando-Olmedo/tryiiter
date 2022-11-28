using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tryiiter.Models;

public class Post
{
    [Column("id")]
    [Key]
    public int PostId { get; set; }
    [Column("content")]
    [Required]
    public string Content { get; set; }
    [Column("category_id")]
    [ForeignKey("CategoryId")]
    [Required]
    public ICollection<Category> CategoryId { get; set; }
    [Column("user_id")]
    [ForeignKey("UserId")]
    [Required]
    public User UserId { get; set; }
    
    [Column("image")]
    [Required]
    public string Image { get; set; }

    [Column("published", TypeName = "Date")]
    public DateTime Published { get; set; }

    [Timestamp]
    [Column("updated")]
    public byte[] Updated { get; set; }
    
    [ForeignKey("PostId")]
    public ICollection<PostCategory> PostCategories { get; set; }
}