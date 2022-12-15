using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace tryiiter.Models;

public class Post : BaseEntity
{
    [ExcludeFromCodeCoverage]
    [Column("id")]
    [Key]
    public long PostId { get; set; }
    [Column("content")]
    [MaxLength(300)]
    [Required]
    public string Content { get; set; }
    [Column("user_id")]
    public long UserId { get; set; }
    public User User { get; set; }
    
    [Column("image")]
    [Required]
    public string Image { get; set; }

    [ForeignKey("PostId")]
    public ICollection<PostCategory> PostCategories { get; set; }
}

public class PostInsert
{
    public string Content { get; set; }
    public long UserId { get; set; }
    public string Image { get; set; }
    public int[] CategoryIds { get; set; }
}

public class PostUpdate
{
    public long Id { get; set; }
    public string? Content { get; set; }
    public long? UserId { get; set; }
    public string? Image { get; set; }
    public int[]? CategoryIds { get; set; }
}

public class BaseEntity
{
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}

public class PostDTO
{
    public long Id { get; set; }
    public string Content { get; set; }
    public long UserId { get; set; }
    public string Image { get; set; }
    public List<int> CategoryIds { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}