using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace tryiiter.Models;

public class User
{
    [ExcludeFromCodeCoverage]
    [Key]
    [Column("id")]
    public long UserId { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("email")]
    public string? Email { get; set; }
    [Column("module")]
    public string? Module { get; set; }
    [Column("status")]
    public string? Status { get; set; }
    [Column("password")]
    public string? Password { get; set; }
    
    public ICollection<Post>? Posts { get; set; }
}

public class UserModuleUpdate
{
    public long UserId { get; set; }
    public string Module { get; set; }
}

public class UserStatusUpdate
{
    public long UserId { get; set; }
    public string Status { get; set; }
}
