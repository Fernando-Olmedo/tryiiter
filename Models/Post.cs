using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tryiiter.Models;

public class Post
{
    [Column("id")]
    [Key]
    public long PostId { get; set; }
    [Column("content")]
    [Required]
    public string Content { get; set; }
    [Column("user_id")]
    [Required]
    public User User { get; set; }
    
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