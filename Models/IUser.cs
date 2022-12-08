namespace tryiiter.Models;

public interface IUser
{
    string Name { get; set; }
    string Email { get; set; }
    string Module { get; set; }
    string Status { get; set; }
    string Password { get; set; } 
}