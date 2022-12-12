using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace tryiiter.Models;

public class Post : BaseEntity
{
    [Column("id")]
    [Key]
    public long PostId { get; set; }
    [Column("content")]
    [Required]
    public string Content { get; set; }
    [Column("user_id")]
    public long UserId { get; set; }
    public User User { get; set; }
    
    [Column("image")]
    [Required]
    public string Image { get; set; }

    // [Column("published", TypeName = "Date")]
    // // [DatabaseGenerated(DatabaseGeneratedOption.Identity), DataMember]
    // public DateTime Published { get; set; }
    //
    // // [Timestamp]
    // [Column("updated")]
    // // [DatabaseGenerated(DatabaseGeneratedOption.Computed), DataMember]
    // public DateTime? Updated { get; set; }
    
    [ForeignKey("PostId")]
    public ICollection<PostCategory> PostCategories { get; set; }
}

// public class PostDTO
// {
//     
// }

public class PostInsert
{
    public string Content { get; set; }
    public long UserId { get; set; }
    public string Image { get; set; }
}

public class BaseEntity
{
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}