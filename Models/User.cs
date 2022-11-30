using System.ComponentModel.DataAnnotations.Schema;

namespace tryiiter.Models;

public class User
{
    [Column("id")]
    public long UserId { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("module")]
    public string Module { get; set; }
    [Column("status")]
    public string Status { get; set; }
    [Column("password")]
    public string Password { get; set; }
}
